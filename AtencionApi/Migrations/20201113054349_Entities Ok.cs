using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtencionApi.Migrations
{
    public partial class EntitiesOk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "AttentionDoctorId",
                table: "Doctors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AttentionBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttentionId = table.Column<int>(nullable: false),
                    BoxId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttentionBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttentionDoctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttentionId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttentionDoctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    AttentionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(nullable: true),
                    AttentionBoxId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boxes_AttentionBoxes_AttentionBoxId",
                        column: x => x.AttentionBoxId,
                        principalTable: "AttentionBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attentions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    InitHour = table.Column<int>(nullable: false),
                    FinishHour = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false),
                    AttentionDoctorId = table.Column<int>(nullable: true),
                    CallId = table.Column<int>(nullable: true),
                    AttentionBoxId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attentions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attentions_AttentionBoxes_AttentionBoxId",
                        column: x => x.AttentionBoxId,
                        principalTable: "AttentionBoxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attentions_AttentionDoctors_AttentionDoctorId",
                        column: x => x.AttentionDoctorId,
                        principalTable: "AttentionDoctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attentions_Calls_CallId",
                        column: x => x.CallId,
                        principalTable: "Calls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Rut = table.Column<string>(nullable: true),
                    MedicalPlan = table.Column<string>(nullable: true),
                    AttentionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Attentions_AttentionId",
                        column: x => x.AttentionId,
                        principalTable: "Attentions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AttentionDoctorId",
                table: "Doctors",
                column: "AttentionDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Attentions_AttentionBoxId",
                table: "Attentions",
                column: "AttentionBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Attentions_AttentionDoctorId",
                table: "Attentions",
                column: "AttentionDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Attentions_CallId",
                table: "Attentions",
                column: "CallId");

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_AttentionBoxId",
                table: "Boxes",
                column: "AttentionBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AttentionId",
                table: "Patients",
                column: "AttentionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AttentionDoctors_AttentionDoctorId",
                table: "Doctors",
                column: "AttentionDoctorId",
                principalTable: "AttentionDoctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AttentionDoctors_AttentionDoctorId",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Boxes");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Attentions");

            migrationBuilder.DropTable(
                name: "AttentionBoxes");

            migrationBuilder.DropTable(
                name: "AttentionDoctors");

            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_AttentionDoctorId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "AttentionDoctorId",
                table: "Doctors");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
