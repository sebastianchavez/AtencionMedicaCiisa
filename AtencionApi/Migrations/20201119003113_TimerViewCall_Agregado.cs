using Microsoft.EntityFrameworkCore.Migrations;

namespace AtencionApi.Migrations
{
    public partial class TimerViewCall_Agregado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimerViewCall",
                table: "Params",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimerViewCall",
                table: "Params");
        }
    }
}
