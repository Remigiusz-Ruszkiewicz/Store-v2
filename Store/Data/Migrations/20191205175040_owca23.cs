using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Data.Migrations
{
    public partial class owca23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Products_ProductId1",
                table: "Basket");

            migrationBuilder.DropIndex(
                name: "IX_Basket_ProductId1",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Basket");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Basket",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Basket_ProductId",
                table: "Basket",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Products_ProductId",
                table: "Basket",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Products_ProductId",
                table: "Basket");

            migrationBuilder.DropIndex(
                name: "IX_Basket_ProductId",
                table: "Basket");

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "Basket",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "Basket",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Basket_ProductId1",
                table: "Basket",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Products_ProductId1",
                table: "Basket",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
