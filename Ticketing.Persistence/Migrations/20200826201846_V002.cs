using Microsoft.EntityFrameworkCore.Migrations;

namespace Ticketing.Persistence.Migrations
{
    public partial class V002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AreaCode",
                table: "Staff",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaCode",
                table: "Clients",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaCode",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "AreaCode",
                table: "Clients");
        }
    }
}
