using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaPros.DataAccess.Migrations
{
    public partial class AddToppingsIdToPizzaType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToppingsId",
                table: "PizzaType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PizzaType_ToppingsId",
                table: "PizzaType",
                column: "ToppingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaType_Toppings_ToppingsId",
                table: "PizzaType",
                column: "ToppingsId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaType_Toppings_ToppingsId",
                table: "PizzaType");

            migrationBuilder.DropIndex(
                name: "IX_PizzaType_ToppingsId",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingsId",
                table: "PizzaType");
        }
    }
}
