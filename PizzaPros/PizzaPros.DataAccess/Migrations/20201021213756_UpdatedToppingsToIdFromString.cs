using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaPros.DataAccess.Migrations
{
    public partial class UpdatedToppingsToIdFromString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaType_Toppings_ToppingsId",
                table: "PizzaType");

            migrationBuilder.DropIndex(
                name: "IX_PizzaType_ToppingsId",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingEight",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingFive",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingFour",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingSeven",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingSix",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingThree",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingsId",
                table: "PizzaType");

            migrationBuilder.AddColumn<string>(
                name: "ToppingEightId",
                table: "PizzaType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToppingFiveId",
                table: "PizzaType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToppingFourId",
                table: "PizzaType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToppingSevenId",
                table: "PizzaType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToppingSixId",
                table: "PizzaType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToppingThreeId",
                table: "PizzaType",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToppingEightId",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingFiveId",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingFourId",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingSevenId",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingSixId",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingThreeId",
                table: "PizzaType");

            migrationBuilder.AddColumn<string>(
                name: "ToppingEight",
                table: "PizzaType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToppingFive",
                table: "PizzaType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToppingFour",
                table: "PizzaType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToppingSeven",
                table: "PizzaType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToppingSix",
                table: "PizzaType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToppingThree",
                table: "PizzaType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToppingsId",
                table: "PizzaType",
                type: "int",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
