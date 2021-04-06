using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagmentApp.DataLayer.Migrations
{
    public partial class ReturnForeignKeyToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderAgreements_Agreements_AgreementId",
                table: "orderAgreements");

            migrationBuilder.DropForeignKey(
                name: "FK_orderAgreements_Orders_OrderId",
                table: "orderAgreements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderAgreements",
                table: "orderAgreements");

            migrationBuilder.RenameTable(
                name: "orderAgreements",
                newName: "OrderAgreements");

            migrationBuilder.RenameIndex(
                name: "IX_orderAgreements_OrderId",
                table: "OrderAgreements",
                newName: "IX_OrderAgreements_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_orderAgreements_AgreementId",
                table: "OrderAgreements",
                newName: "IX_OrderAgreements_AgreementId");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreating",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderAgreements",
                table: "OrderAgreements",
                columns: new[] { "OrderId", "AgreementId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAgreements_Agreements_AgreementId",
                table: "OrderAgreements",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderAgreements_Orders_OrderId",
                table: "OrderAgreements",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderAgreements_Agreements_AgreementId",
                table: "OrderAgreements");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderAgreements_Orders_OrderId",
                table: "OrderAgreements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderAgreements",
                table: "OrderAgreements");

            migrationBuilder.RenameTable(
                name: "OrderAgreements",
                newName: "orderAgreements");

            migrationBuilder.RenameIndex(
                name: "IX_OrderAgreements_OrderId",
                table: "orderAgreements",
                newName: "IX_orderAgreements_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderAgreements_AgreementId",
                table: "orderAgreements",
                newName: "IX_orderAgreements_AgreementId");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreating",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderAgreements",
                table: "orderAgreements",
                columns: new[] { "OrderId", "AgreementId" });

            migrationBuilder.AddForeignKey(
                name: "FK_orderAgreements_Agreements_AgreementId",
                table: "orderAgreements",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderAgreements_Orders_OrderId",
                table: "orderAgreements",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
