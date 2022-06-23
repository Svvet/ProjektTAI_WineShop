using Microsoft.EntityFrameworkCore.Migrations;

namespace WineShop.Data.Migrations
{
    public partial class ChangeWines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Wines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Producer",
                table: "Wines",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "Producer",
                table: "Wines");
        }
    }
}
