using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCorePartCommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMigToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderItems");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ShippToAddress_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippToAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippToAddress_StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippToAddress_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippToAddress_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DelivaryMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentIntendId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_DelivaryMethods_DelivaryMethodId",
                        column: x => x.DelivaryMethodId,
                        principalTable: "DelivaryMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderItemes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemOrderedProductItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quentity = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderItemes_ProductItemOrdered_ItemOrderedProductItemId",
                        column: x => x.ItemOrderedProductItemId,
                        principalTable: "ProductItemOrdered",
                        principalColumn: "ProductItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderItemes_orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderItemes_ItemOrderedProductItemId",
                table: "orderItemes",
                column: "ItemOrderedProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItemes_OrdersId",
                table: "orderItemes",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_DelivaryMethodId",
                table: "orders",
                column: "DelivaryMethodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderItemes");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DelivaryMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PaymentIntendId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    ShippToAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippToAddress_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippToAddress_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippToAddress_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippToAddress_StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_DelivaryMethods_DelivaryMethodId",
                        column: x => x.DelivaryMethodId,
                        principalTable: "DelivaryMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemOrderedProductItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quentity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderItems_ProductItemOrdered_ItemOrderedProductItemId",
                        column: x => x.ItemOrderedProductItemId,
                        principalTable: "ProductItemOrdered",
                        principalColumn: "ProductItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderItems_order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_DelivaryMethodId",
                table: "order",
                column: "DelivaryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_ItemOrderedProductItemId",
                table: "orderItems",
                column: "ItemOrderedProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_OrderId",
                table: "orderItems",
                column: "OrderId");
        }
    }
}
