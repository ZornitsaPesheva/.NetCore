using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcShopping.Migrations
{
    public partial class Store : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Store",
                table: "ShoppingDay",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Store",
                table: "ShoppingDay");
        }
    }
}
