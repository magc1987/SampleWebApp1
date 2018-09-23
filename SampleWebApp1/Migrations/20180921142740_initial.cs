using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleWebApp1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Patients_PersonId",
                table: "Admissions");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Admissions",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Admissions",
                newName: "AdmissionDate");

            migrationBuilder.RenameIndex(
                name: "IX_Admissions_PersonId",
                table: "Admissions",
                newName: "IX_Admissions_PatientId");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "ItemOrderDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Patients_PatientId",
                table: "Admissions",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_Patients_PatientId",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "ItemOrderDetails");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Admissions",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "AdmissionDate",
                table: "Admissions",
                newName: "OrderDate");

            migrationBuilder.RenameIndex(
                name: "IX_Admissions_PatientId",
                table: "Admissions",
                newName: "IX_Admissions_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_Patients_PersonId",
                table: "Admissions",
                column: "PersonId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
