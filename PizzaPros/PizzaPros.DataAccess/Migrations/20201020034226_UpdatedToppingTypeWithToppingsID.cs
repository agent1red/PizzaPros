using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaPros.DataAccess.Migrations
{
    public partial class UpdatedToppingTypeWithToppingsID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToppingsId1",
                table: "PizzaType",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PizzaType_ToppingsId1",
                table: "PizzaType",
                column: "ToppingsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaType_Toppings_ToppingsId1",
                table: "PizzaType",
                column: "ToppingsId1",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaType_Toppings_ToppingsId1",
                table: "PizzaType");

            migrationBuilder.DropIndex(
                name: "IX_PizzaType_ToppingsId1",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingsId1",
                table: "PizzaType");
        }
    }
}
