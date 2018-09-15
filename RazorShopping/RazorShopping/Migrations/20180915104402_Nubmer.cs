using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorShopping.Migrations
{
    public partial class Nubmer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Number",
                table: "Item",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Item");
        }
    }
}
