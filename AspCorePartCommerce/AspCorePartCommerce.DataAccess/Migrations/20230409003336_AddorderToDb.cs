using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCorePartCommerce.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddorderToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DelivaryMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    shortTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DelivaryTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelivaryMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemOrdered",
                columns: table => new
                {
                    ProductItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemOrdered", x => x.ProductItemId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ShippToAddress_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippToAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippToAddress_StreetAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippToAddress_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippToAddress_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DelivaryMethodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentIntendId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_DelivaryMethods_DelivaryMethodId",
                        column: x => x.DelivaryMethodId,
                        principalTable: "DelivaryMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemOrderedProductItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quentity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductItemOrdered_ItemOrderedProductItemId",
                        column: x => x.ItemOrderedProductItemId,
                        principalTable: "ProductItemOrdered",
                        principalColumn: "ProductItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_DelivaryMethodId",
                table: "Order",
                column: "DelivaryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemOrderedProductItemId",
                table: "OrderItems",
                column: "ItemOrderedProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ProductItemOrdered");

            migrationBuilder.DropTable(
                name: "DelivaryMethods");
        }
    }
}
