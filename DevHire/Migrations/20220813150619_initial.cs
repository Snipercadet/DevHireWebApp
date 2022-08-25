using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHire.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<double>(type: "float", nullable: false),
                    IsFavourite = table.Column<bool>(type: "bit", nullable: false),
                    IsHired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Devs",
                columns: new[] { "Id", "Fee", "IsFavourite", "IsHired", "Name", "Skill" },
                values: new object[,]
                {
                    { 1, 1000.0, true, false, "Bernard Promise", "Frontend Engineer" },
                    { 2, 5000.0, false, true, "Sunday Ogbonna", "Frontend Engineer with react" },
                    { 3, 7000.0, true, false, "Favour Ebrusike", "Fullstack Engineer" },
                    { 4, 10000.0, true, true, "Zikorah", "Project Manager" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devs");
        }
    }
}
