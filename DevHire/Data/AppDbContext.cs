using Microsoft.EntityFrameworkCore;

namespace DevHire.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Dev> Devs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dev>().HasData(
                new Dev
                {
                    Id = 1,
                    Name = "Bernard Promise",
                    Skill = "Frontend Engineer",
                    Fee = 1000,
                    IsFavourite = true,
                    IsHired = false
                },
                new Dev
                {
                    Id=2,
                    Name = "Sunday Ogbonna",
                    Skill = "Frontend Engineer with react",
                    Fee=5000,
                    IsFavourite=false,
                    IsHired=true
                },
                new Dev
                {
                    Id=3,
                    Name = "Favour Ebrusike",
                    Skill = "Fullstack Engineer",
                    Fee=7000,
                    IsFavourite = true,
                    IsHired= false,
                },
                new Dev
                {
                    Id=4,
                    Name="Zikorah",
                    Skill="Project Manager",
                    Fee = 10000,
                    IsFavourite= true,
                    IsHired = true,
                });
        }
    }

}
