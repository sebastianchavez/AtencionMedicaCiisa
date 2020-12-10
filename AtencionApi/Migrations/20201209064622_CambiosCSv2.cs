using Microsoft.EntityFrameworkCore.Migrations;

namespace AtencionApi.Migrations
{
    public partial class CambiosCSv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Patiens",
                table: "Csv");

            migrationBuilder.AddColumn<int>(
                name: "Patients",
                table: "Csv",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Patients",
                table: "Csv");

            migrationBuilder.AddColumn<int>(
                name: "Patiens",
                table: "Csv",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
