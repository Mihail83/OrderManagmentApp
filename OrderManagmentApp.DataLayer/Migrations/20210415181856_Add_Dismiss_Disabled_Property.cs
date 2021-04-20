using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagmentApp.DataLayer.Migrations
{
    public partial class Add_Dismiss_Disabled_Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDismissed",
                table: "ShipmentSpecialists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "ShipmentDestinations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDismissed",
                table: "Managers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDismissed",
                table: "ShipmentSpecialists");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "ShipmentDestinations");

            migrationBuilder.DropColumn(
                name: "IsDismissed",
                table: "Managers");
        }
    }
}
