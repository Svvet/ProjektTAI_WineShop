using Microsoft.EntityFrameworkCore.Migrations;

namespace WineShop.Data.Migrations
{
    public partial class Basket2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Basket_OrderBasketId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Basket_BasketId",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Basket",
                table: "Basket");

            migrationBuilder.RenameTable(
                name: "Basket",
                newName: "Baskets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baskets",
                table: "Baskets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Baskets_OrderBasketId",
                table: "Orders",
                column: "OrderBasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Baskets_BasketId",
                table: "Positions",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Baskets_OrderBasketId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Baskets_BasketId",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Baskets",
                table: "Baskets");

            migrationBuilder.RenameTable(
                name: "Baskets",
                newName: "Basket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Basket",
                table: "Basket",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Basket_OrderBasketId",
                table: "Orders",
                column: "OrderBasketId",
                principalTable: "Basket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Basket_BasketId",
                table: "Positions",
                column: "BasketId",
                principalTable: "Basket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
