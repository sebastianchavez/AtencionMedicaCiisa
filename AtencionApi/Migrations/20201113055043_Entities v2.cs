using Microsoft.EntityFrameworkCore.Migrations;

namespace AtencionApi.Migrations
{
    public partial class Entitiesv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attentions_AttentionBoxes_AttentionBoxId",
                table: "Attentions");

            migrationBuilder.DropForeignKey(
                name: "FK_Attentions_AttentionDoctors_AttentionDoctorId",
                table: "Attentions");

            migrationBuilder.DropForeignKey(
                name: "FK_Attentions_Calls_CallId",
                table: "Attentions");

            migrationBuilder.DropForeignKey(
                name: "FK_Boxes_AttentionBoxes_AttentionBoxId",
                table: "Boxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_AttentionDoctors_AttentionDoctorId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Attentions_AttentionId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AttentionId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_AttentionDoctorId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Boxes_AttentionBoxId",
                table: "Boxes");

            migrationBuilder.DropIndex(
                name: "IX_Attentions_AttentionBoxId",
                table: "Attentions");

            migrationBuilder.DropIndex(
                name: "IX_Attentions_AttentionDoctorId",
                table: "Attentions");

            migrationBuilder.DropIndex(
                name: "IX_Attentions_CallId",
                table: "Attentions");

            migrationBuilder.DropColumn(
                name: "AttentionId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AttentionDoctorId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "AttentionBoxId",
                table: "Boxes");

            migrationBuilder.DropColumn(
                name: "AttentionBoxId",
                table: "Attentions");

            migrationBuilder.DropColumn(
                name: "AttentionDoctorId",
                table: "Attentions");

            migrationBuilder.DropColumn(
                name: "CallId",
                table: "Attentions");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_AttentionId",
                table: "Calls",
                column: "AttentionId");

            migrationBuilder.CreateIndex(
                name: "IX_Attentions_PatientId",
                table: "Attentions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AttentionDoctors_AttentionId",
                table: "AttentionDoctors",
                column: "AttentionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttentionDoctors_DoctorId",
                table: "AttentionDoctors",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AttentionBoxes_AttentionId",
                table: "AttentionBoxes",
                column: "AttentionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttentionBoxes_BoxId",
                table: "AttentionBoxes",
                column: "BoxId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttentionBoxes_Attentions_AttentionId",
                table: "AttentionBoxes",
                column: "AttentionId",
                principalTable: "Attentions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttentionBoxes_Boxes_BoxId",
                table: "AttentionBoxes",
                column: "BoxId",
                principalTable: "Boxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttentionDoctors_Attentions_AttentionId",
                table: "AttentionDoctors",
                column: "AttentionId",
                principalTable: "Attentions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttentionDoctors_Doctors_DoctorId",
                table: "AttentionDoctors",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attentions_Patients_PatientId",
                table: "Attentions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Attentions_AttentionId",
                table: "Calls",
                column: "AttentionId",
                principalTable: "Attentions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttentionBoxes_Attentions_AttentionId",
                table: "AttentionBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_AttentionBoxes_Boxes_BoxId",
                table: "AttentionBoxes");

            migrationBuilder.DropForeignKey(
                name: "FK_AttentionDoctors_Attentions_AttentionId",
                table: "AttentionDoctors");

            migrationBuilder.DropForeignKey(
                name: "FK_AttentionDoctors_Doctors_DoctorId",
                table: "AttentionDoctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Attentions_Patients_PatientId",
                table: "Attentions");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Attentions_AttentionId",
                table: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Calls_AttentionId",
                table: "Calls");

            migrationBuilder.DropIndex(
                name: "IX_Attentions_PatientId",
                table: "Attentions");

            migrationBuilder.DropIndex(
                name: "IX_AttentionDoctors_AttentionId",
                table: "AttentionDoctors");

            migrationBuilder.DropIndex(
                name: "IX_AttentionDoctors_DoctorId",
                table: "AttentionDoctors");

            migrationBuilder.DropIndex(
                name: "IX_AttentionBoxes_AttentionId",
                table: "AttentionBoxes");

            migrationBuilder.DropIndex(
                name: "IX_AttentionBoxes_BoxId",
                table: "AttentionBoxes");

            migrationBuilder.AddColumn<int>(
                name: "AttentionId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttentionDoctorId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttentionBoxId",
                table: "Boxes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttentionBoxId",
                table: "Attentions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttentionDoctorId",
                table: "Attentions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CallId",
                table: "Attentions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AttentionId",
                table: "Patients",
                column: "AttentionId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AttentionDoctorId",
                table: "Doctors",
                column: "AttentionDoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_AttentionBoxId",
                table: "Boxes",
                column: "AttentionBoxId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Attentions_AttentionBoxes_AttentionBoxId",
                table: "Attentions",
                column: "AttentionBoxId",
                principalTable: "AttentionBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attentions_AttentionDoctors_AttentionDoctorId",
                table: "Attentions",
                column: "AttentionDoctorId",
                principalTable: "AttentionDoctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attentions_Calls_CallId",
                table: "Attentions",
                column: "CallId",
                principalTable: "Calls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Boxes_AttentionBoxes_AttentionBoxId",
                table: "Boxes",
                column: "AttentionBoxId",
                principalTable: "AttentionBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_AttentionDoctors_AttentionDoctorId",
                table: "Doctors",
                column: "AttentionDoctorId",
                principalTable: "AttentionDoctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Attentions_AttentionId",
                table: "Patients",
                column: "AttentionId",
                principalTable: "Attentions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
