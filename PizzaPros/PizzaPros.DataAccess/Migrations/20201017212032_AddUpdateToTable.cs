using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaPros.DataAccess.Migrations
{
    public partial class AddUpdateToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaType_PizzaCrustType_PizzaCrustFlavorId",
                table: "PizzaType");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "PizzaType",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaType_PizzaCrustFlavor_PizzaCrustFlavorId",
                table: "PizzaType",
                column: "PizzaCrustFlavorId",
                principalTable: "PizzaCrustFlavor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaType_PizzaCrustFlavor_PizzaCrustFlavorId",
                table: "PizzaType");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "PizzaType",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaType_PizzaCrustType_PizzaCrustFlavorId",
                table: "PizzaType",
                column: "PizzaCrustFlavorId",
                principalTable: "PizzaCrustType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
