using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab4.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolutionsData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    A = table.Column<int>(type: "INTEGER", nullable: false),
                    B = table.Column<int>(type: "INTEGER", nullable: false),
                    C = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfRoots = table.Column<int>(type: "INTEGER", nullable: false),
                    Root1 = table.Column<double>(type: "REAL", nullable: false),
                    Root2 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolutionsData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolutionsData");
        }
    }
}
