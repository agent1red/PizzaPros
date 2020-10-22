using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaPros.DataAccess.Migrations
{
    public partial class AddToppingsIdToPizzaTypeForToppingOneAndTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaType_Toppings_ToppingsId",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingOne",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingTwo",
                table: "PizzaType");

            migrationBuilder.AlterColumn<int>(
                name: "ToppingsId",
                table: "PizzaType",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ToppingOneId",
                table: "PizzaType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToppingTwoId",
                table: "PizzaType",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaType_Toppings_ToppingsId",
                table: "PizzaType",
                column: "ToppingsId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaType_Toppings_ToppingsId",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingOneId",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "ToppingTwoId",
                table: "PizzaType");

            migrationBuilder.AlterColumn<int>(
                name: "ToppingsId",
                table: "PizzaType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToppingOne",
                table: "PizzaType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToppingTwo",
                table: "PizzaType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaType_Toppings_ToppingsId",
                table: "PizzaType",
                column: "ToppingsId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
