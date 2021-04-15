using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagmentApp.DataLayer.Migrations
{
    public partial class Index_agreementId_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderAgreements_AgreementId",
                table: "OrderAgreements");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAgreements_AgreementId",
                table: "OrderAgreements",
                column: "AgreementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderAgreements_AgreementId",
                table: "OrderAgreements");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAgreements_AgreementId",
                table: "OrderAgreements",
                column: "AgreementId",
                unique: true);
        }
    }
}
