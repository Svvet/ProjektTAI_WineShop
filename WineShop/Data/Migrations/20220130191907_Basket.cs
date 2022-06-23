using Microsoft.EntityFrameworkCore.Migrations;

namespace WineShop.Data.Migrations
{
    public partial class Basket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Orders_OrderId",
                table: "Positions");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Positions",
                newName: "BasketId");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_OrderId",
                table: "Positions",
                newName: "IX_Positions_BasketId");

            migrationBuilder.AddColumn<int>(
                name: "OrderBasketId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Realised",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ordered = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderBasketId",
                table: "Orders",
                column: "OrderBasketId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Basket_OrderBasketId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Basket_BasketId",
                table: "Positions");

            migrationBuilder.DropTable(
                name: "Basket");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderBasketId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderBasketId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Realised",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "BasketId",
                table: "Positions",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_BasketId",
                table: "Positions",
                newName: "IX_Positions_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Orders_OrderId",
                table: "Positions",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
