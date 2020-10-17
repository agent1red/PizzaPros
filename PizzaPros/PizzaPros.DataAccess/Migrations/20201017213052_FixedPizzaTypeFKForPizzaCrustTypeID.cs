using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaPros.DataAccess.Migrations
{
    public partial class FixedPizzaTypeFKForPizzaCrustTypeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaType_PizzaCrustType_PizzaCrustId",
                table: "PizzaType");

            migrationBuilder.DropIndex(
                name: "IX_PizzaType_PizzaCrustId",
                table: "PizzaType");

            migrationBuilder.DropColumn(
                name: "PizzaCrustId",
                table: "PizzaType");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaType_PizzaCrustTypeId",
                table: "PizzaType",
                column: "PizzaCrustTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaType_PizzaCrustType_PizzaCrustTypeId",
                table: "PizzaType",
                column: "PizzaCrustTypeId",
                principalTable: "PizzaCrustType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaType_PizzaCrustType_PizzaCrustTypeId",
                table: "PizzaType");

            migrationBuilder.DropIndex(
                name: "IX_PizzaType_PizzaCrustTypeId",
                table: "PizzaType");

            migrationBuilder.AddColumn<int>(
                name: "PizzaCrustId",
                table: "PizzaType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PizzaType_PizzaCrustId",
                table: "PizzaType",
                column: "PizzaCrustId");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaType_PizzaCrustType_PizzaCrustId",
                table: "PizzaType",
                column: "PizzaCrustId",
                principalTable: "PizzaCrustType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
