using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaPros.DataAccess.Migrations
{
    public partial class AddCategoryToShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ShoppingCart",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ShoppingCart");
        }
    }
}
