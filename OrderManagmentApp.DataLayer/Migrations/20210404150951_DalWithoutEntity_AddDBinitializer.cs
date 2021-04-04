using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagmentApp.DataLayer.Migrations
{
    public partial class DalWithoutEntity_AddDBinitializer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderEntityAgreementEntity");

            migrationBuilder.DropTable(
                name: "Сontracts");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShipmentDestinations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShipmentDestinations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShipmentSpecialists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShipmentSpecialists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Phones_FirstNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phones_SecondNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Phones_ThirdNumber",
                table: "Customers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreating",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "Phones",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Agreements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Good = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sum = table.Column<decimal>(type: "money", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agreements_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "orderAgreements",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    AgreementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderAgreements", x => new { x.OrderId, x.AgreementId });
                    table.ForeignKey(
                        name: "FK_orderAgreements_Agreements_AgreementId",
                        column: x => x.AgreementId,
                        principalTable: "Agreements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderAgreements_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agreements_CustomerId",
                table: "Agreements",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_orderAgreements_AgreementId",
                table: "orderAgreements",
                column: "AgreementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderAgreements_OrderId",
                table: "orderAgreements",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderAgreements");

            migrationBuilder.DropTable(
                name: "Agreements");

            migrationBuilder.DropColumn(
                name: "Phones",
                table: "Customers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfCreating",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 2, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "Phones_FirstNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phones_SecondNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phones_ThirdNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Сontracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Good = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sum = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сontracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Сontracts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "FirstTestManager" },
                    { 2, "SecondTestManager" }
                });

            migrationBuilder.InsertData(
                table: "ShipmentDestinations",
                columns: new[] { "Id", "Destination" },
                values: new object[,]
                {
                    { 1, "destination1" },
                    { 2, "destination2222" }
                });

            migrationBuilder.InsertData(
                table: "ShipmentSpecialists",
                columns: new[] { "Id", "Specialist" },
                values: new object[,]
                {
                    { 1, "specialist1" },
                    { 2, "specialist2222" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Сontracts_CustomerId",
                table: "Сontracts",
                column: "CustomerId");
        }
    }
}
