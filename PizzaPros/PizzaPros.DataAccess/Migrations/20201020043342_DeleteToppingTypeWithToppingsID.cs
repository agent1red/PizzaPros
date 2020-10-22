using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaPros.DataAccess.Migrations
{
    public partial class DeleteToppingTypeWithToppingsID : Migration
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
                name: "ToppingsId",
                table: "PizzaType");

            migrationBuilder.AlterColumn<string>(
                name: "ToppingTwo",
                table: "PizzaType",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ToppingOne",
                table: "PizzaType",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ToppingTwo",
                table: "PizzaType",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ToppingOne",
                table: "PizzaType",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToppingsId",
                table: "PizzaType",
                type: "int",
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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
