using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticketing.Persistence.Migrations
{
    public partial class V003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductPriority",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "TicketPriority",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketPriority",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductPriority",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
