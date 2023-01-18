using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multishop.Migrations
{
    /// <inheritdoc />
    public partial class modifiedtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductInformations_Products_ProductId",
                table: "ProductInformations");

            migrationBuilder.DropIndex(
                name: "IX_ProductInformations_ProductId",
                table: "ProductInformations");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductInformations");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "ProductInformations",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "ProductInformationId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductInformationId",
                table: "Products",
                column: "ProductInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductInformations_ProductInformationId",
                table: "Products",
                column: "ProductInformationId",
                principalTable: "ProductInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductInformations_ProductInformationId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductInformationId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductInformationId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductInformations",
                newName: "Key");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductInformations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInformations_ProductId",
                table: "ProductInformations",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInformations_Products_ProductId",
                table: "ProductInformations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
