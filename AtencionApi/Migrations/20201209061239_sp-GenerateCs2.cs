using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtencionApi.Migrations
{
    public partial class spGenerateCs2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Csv",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Box = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Patiens = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Csv", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Csv");
        }
    }
}
