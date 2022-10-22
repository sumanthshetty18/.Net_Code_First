using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TE_CodeFirst.Migrations
{
    public partial class initdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    TraineeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraineeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraineeAge = table.Column<int>(type: "int", nullable: false),
                    TraineeDOJ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TraineeDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TraineeMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraineeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraineePassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraineeConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee", x => x.TraineeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainee");
        }
    }
}
