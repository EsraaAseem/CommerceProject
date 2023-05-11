using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCorePartCommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addorderuptodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_DelivaryMethods_DelivaryMethodId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_orderItemes_Order_OrdersId",
                table: "orderItemes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DelivaryMethodId",
                table: "Orders",
                newName: "IX_Orders_DelivaryMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItemes_Orders_OrdersId",
                table: "orderItemes",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DelivaryMethods_DelivaryMethodId",
                table: "Orders",
                column: "DelivaryMethodId",
                principalTable: "DelivaryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItemes_Orders_OrdersId",
                table: "orderItemes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DelivaryMethods_DelivaryMethodId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DelivaryMethodId",
                table: "Order",
                newName: "IX_Order_DelivaryMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DelivaryMethods_DelivaryMethodId",
                table: "Order",
                column: "DelivaryMethodId",
                principalTable: "DelivaryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderItemes_Order_OrdersId",
                table: "orderItemes",
                column: "OrdersId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
