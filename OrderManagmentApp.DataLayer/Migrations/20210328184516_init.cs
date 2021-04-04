using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace OrderManagmentApp.DataLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumbers_FirstNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumbers_SecondNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumbers_ThirdNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emeil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_TaxPayerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Bank_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Bank_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Bank_Account = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_OKPO = table.Column<decimal>(type: "decimal(20,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentDestinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentDestinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentSpecialists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Specialist = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentSpecialists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Сontracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 3, 28, 0, 0, 0, 0, DateTimeKind.Local)),
                    Good = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sum = table.Column<decimal>(type: "money", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateOfCreating = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 3, 28, 0, 0, 0, 0, DateTimeKind.Local)),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CurrentAgreement = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Good = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContractSum = table.Column<decimal>(type: "money", nullable: false),
                    Advance = table.Column<decimal>(type: "money", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OrderState = table.Column<int>(type: "int", nullable: false),
                    ShipmentSpecialistId = table.Column<int>(type: "int", nullable: true),
                    ShipmentDestinationId = table.Column<int>(type: "int", nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ShipmentDestinations_ShipmentDestinationId",
                        column: x => x.ShipmentDestinationId,
                        principalTable: "ShipmentDestinations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ShipmentSpecialists_ShipmentSpecialistId",
                        column: x => x.ShipmentSpecialistId,
                        principalTable: "ShipmentSpecialists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderByALutehs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    StateOfSet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StateOfShipment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sum = table.Column<decimal>(type: "money", nullable: false),
                    PaymentedSum = table.Column<decimal>(type: "money", nullable: false),
                    StateOfPayment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateOfOrder = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderByALutehs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderByALutehs_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
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
                name: "IX_Managers_Name",
                table: "Managers",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderByALutehs_OrderId",
                table: "OrderByALutehs",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ManagerId",
                table: "Orders",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipmentDestinationId",
                table: "Orders",
                column: "ShipmentDestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipmentSpecialistId",
                table: "Orders",
                column: "ShipmentSpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentDestinations_Destination",
                table: "ShipmentDestinations",
                column: "Destination",
                unique: true,
                filter: "[Destination] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Сontracts_CustomerId",
                table: "Сontracts",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderByALutehs");

            migrationBuilder.DropTable(
                name: "Сontracts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "ShipmentDestinations");

            migrationBuilder.DropTable(
                name: "ShipmentSpecialists");
        }
    }
}
