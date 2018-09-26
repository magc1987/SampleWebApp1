using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleWebApp1.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Patients",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ItemOrderDetails",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "ItemOrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Admissions",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Patients",
                nullable: true,
                computedColumnSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "ItemOrderDetails",
                nullable: true,
                computedColumnSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Admissions",
                nullable: true,
                computedColumnSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ItemOrderDetails");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "ItemOrderDetails");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "ItemOrderDetails");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Admissions");
        }
    }
}
