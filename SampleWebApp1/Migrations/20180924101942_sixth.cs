using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleWebApp1.Migrations
{
    public partial class sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Patients",
                nullable: false,
                computedColumnSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldComputedColumnSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "ItemOrderDetails",
                nullable: false,
                computedColumnSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldComputedColumnSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Admissions",
                nullable: false,
                computedColumnSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldComputedColumnSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Patients",
                nullable: true,
                computedColumnSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldComputedColumnSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "ItemOrderDetails",
                nullable: true,
                computedColumnSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldComputedColumnSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "Admissions",
                nullable: true,
                computedColumnSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldComputedColumnSql: "getdate()");
        }
    }
}
