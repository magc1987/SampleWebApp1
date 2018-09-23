using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleWebApp1.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrderDetails_Admissions_OrderID",
                table: "ItemOrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderDescription",
                table: "ItemOrderDetails");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "ItemOrderDetails",
                newName: "AdmissionId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrderDetails_OrderID",
                table: "ItemOrderDetails",
                newName: "IX_ItemOrderDetails_AdmissionId");

            migrationBuilder.AddColumn<string>(
                name: "SupplyName",
                table: "Supplies",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrderDetails_Admissions_AdmissionId",
                table: "ItemOrderDetails",
                column: "AdmissionId",
                principalTable: "Admissions",
                principalColumn: "AdmissionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOrderDetails_Admissions_AdmissionId",
                table: "ItemOrderDetails");

            migrationBuilder.DropColumn(
                name: "SupplyName",
                table: "Supplies");

            migrationBuilder.RenameColumn(
                name: "AdmissionId",
                table: "ItemOrderDetails",
                newName: "OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_ItemOrderDetails_AdmissionId",
                table: "ItemOrderDetails",
                newName: "IX_ItemOrderDetails_OrderID");

            migrationBuilder.AddColumn<string>(
                name: "OrderDescription",
                table: "ItemOrderDetails",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOrderDetails_Admissions_OrderID",
                table: "ItemOrderDetails",
                column: "OrderID",
                principalTable: "Admissions",
                principalColumn: "AdmissionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
