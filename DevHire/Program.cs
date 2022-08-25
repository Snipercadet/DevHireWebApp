using DevHire.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("Dbcon")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/Devs", async (AppDbContext db) =>
    await db.Devs.ToListAsync()
);

app.MapGet("/Devs/Favourite", async (AppDbContext db) =>
    await db.Devs.Where(q=>q.IsFavourite).ToListAsync()
);

app.MapGet("/Devs/Hired", async (AppDbContext db) =>
    await db.Devs.Where(q => q.IsHired).ToListAsync()
);
app.MapGet("/Devs/{id}", async (int id, AppDbContext db) =>
    await db.Devs.FirstOrDefaultAsync(o => o.Id == id)
     is Dev dev
     ? Results.Ok(dev)
     : Results.NotFound()
);
app.MapPut("/Devs/{id}", async (int id, Dev dev, AppDbContext db) =>
{
    var data = await db.Devs.FirstOrDefaultAsync(x => x.Id == id);
    if (data is null) return Results.NotFound();

    data.Name = dev.Name;
    data.Skill = dev.Skill;
    data.IsFavourite = dev.IsFavourite;
    data.IsHired = dev.IsHired;
    data.Fee = dev.Fee;

    await db.SaveChangesAsync();
    return Results.NoContent();

});

app.MapPost("/Devs", async (Dev dev, AppDbContext db) =>
{
    db.Add(dev);
    await db.SaveChangesAsync();
    return Results.Created($"/Devs/{dev.Id}", dev);
});

app.MapDelete("/Devs/{id}", async (int id, AppDbContext db) =>
{
    var data = await db.Devs.FirstOrDefaultAsync(a => a.Id == id);
    if (data is null) return Results.NotFound();
    db.Devs.Remove(data);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();

