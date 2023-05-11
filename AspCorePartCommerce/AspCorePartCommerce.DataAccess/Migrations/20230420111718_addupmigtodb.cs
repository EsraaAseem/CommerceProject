using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCorePartCommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addupmigtodb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItemes_orders_OrdersId",
                table: "orderItemes");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_DelivaryMethods_DelivaryMethodId",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_orders_DelivaryMethodId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DelivaryMethodId",
                table: "orders",
                newName: "IX_orders_DelivaryMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItemes_orders_OrdersId",
                table: "orderItemes",
                column: "OrdersId",
                principalTable: "orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_DelivaryMethods_DelivaryMethodId",
                table: "orders",
                column: "DelivaryMethodId",
                principalTable: "DelivaryMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
