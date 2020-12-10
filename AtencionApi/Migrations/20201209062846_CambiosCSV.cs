using Microsoft.EntityFrameworkCore.Migrations;

namespace AtencionApi.Migrations
{
    public partial class CambiosCSV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Csv",
                table: "Csv");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Csv");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Csv",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Csv",
                table: "Csv",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Csv",
                table: "Csv");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Csv",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Csv",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Csv",
                table: "Csv",
                column: "Id");
        }
    }
}
