using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace OrderManagmentApp.DataLayer.Migrations
{
    public partial class ChangePhoneCollumName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumbers_ThirdNumber",
                table: "Customers",
                newName: "Phones_ThirdNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNumbers_SecondNumber",
                table: "Customers",
                newName: "Phones_SecondNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNumbers_FirstNumber",
                table: "Customers",
                newName: "Phones_FirstNumber");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Customers",
                newName: "AdditionalInfo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreating",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 30, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 28, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phones_ThirdNumber",
                table: "Customers",
                newName: "PhoneNumbers_ThirdNumber");

            migrationBuilder.RenameColumn(
                name: "Phones_SecondNumber",
                table: "Customers",
                newName: "PhoneNumbers_SecondNumber");

            migrationBuilder.RenameColumn(
                name: "Phones_FirstNumber",
                table: "Customers",
                newName: "PhoneNumbers_FirstNumber");

            migrationBuilder.RenameColumn(
                name: "AdditionalInfo",
                table: "Customers",
                newName: "Comment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreating",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 3, 28, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 3, 30, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
