using Microsoft.EntityFrameworkCore.Migrations;

namespace WineShop.Data.Migrations
{
    public partial class ChangeWines2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Wines");

            migrationBuilder.AddColumn<double>(
                name: "Alcohol",
                table: "Wines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alcohol",
                table: "Wines");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Wines",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
