using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagmentApp.DataLayer.Migrations
{
    public partial class ChangeCustomerEntity_removeBankAndCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company_Bank_Account",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Company_Bank_Name",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Company_OKPO",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Company_Bank_Number",
                table: "Customers",
                newName: "Company_BankAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Company_BankAccount",
                table: "Customers",
                newName: "Company_Bank_Number");

            migrationBuilder.AddColumn<string>(
                name: "Company_Bank_Account",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company_Bank_Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Company_OKPO",
                table: "Customers",
                type: "decimal(20,0)",
                nullable: true);
        }
    }
}
