using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixDecimalColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    BasketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false,
                        defaultValueSql: "GETUTCDATE()"),  // ✅ EKLE
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false,
                        defaultValueSql: "GETUTCDATE()"),  // ✅ EKLE
                    MenuTableID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.BasketID);
                    table.ForeignKey(
                        name: "FK_Baskets_MenuTables_MenuTableID",
                        column: x => x.MenuTableID,
                        principalTable: "MenuTables",
                        principalColumn: "MenuTableID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketProducts",
                columns: table => new
                {
                    BasketID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)  // ✅ EKLE
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketProducts", x => new { x.BasketID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_BasketProducts_Baskets_BasketID",
                        column: x => x.BasketID,
                        principalTable: "Baskets",
                        principalColumn: "BasketID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            


            migrationBuilder.CreateIndex(
                name: "IX_BasketProducts_ProductID",
                table: "BasketProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_MenuTableID",
                table: "Baskets",
                column: "MenuTableID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Baskets_BasketID",
                table: "Orders",
                column: "BasketID",
                principalTable: "Baskets",
                principalColumn: "BasketID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Baskets_BasketID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "BasketProducts");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BasketID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Date",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BasketID",
                table: "Orders");
        }
    }
}