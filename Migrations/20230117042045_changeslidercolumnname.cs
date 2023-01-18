using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multishop.Migrations
{
    /// <inheritdoc />
    public partial class changeslidercolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Sliders",
                newName: "Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Sliders",
                newName: "Count");
        }
    }
}
