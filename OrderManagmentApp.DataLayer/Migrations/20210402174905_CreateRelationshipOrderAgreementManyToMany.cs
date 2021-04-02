using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagmentApp.DataLayer.Migrations
{
    public partial class CreateRelationshipOrderAgreementManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentAgreement",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreating",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 2, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateTable(
                name: "OrderEntityAgreementEntity",
                columns: table => new
                {
                    OrderEntityId = table.Column<int>(type: "int", nullable: false),
                    AgreementEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntityAgreementEntity", x => new { x.OrderEntityId, x.AgreementEntityId });
                    table.ForeignKey(
                        name: "FK_OrderEntityAgreementEntity_Orders_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderEntityAgreementEntity_Сontracts_AgreementEntityId",
                        column: x => x.AgreementEntityId,
                        principalTable: "Сontracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntityAgreementEntity_AgreementEntityId",
                table: "OrderEntityAgreementEntity",
                column: "AgreementEntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntityAgreementEntity_OrderEntityId",
                table: "OrderEntityAgreementEntity",
                column: "OrderEntityId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderEntityAgreementEntity");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreating",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "CurrentAgreement",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
