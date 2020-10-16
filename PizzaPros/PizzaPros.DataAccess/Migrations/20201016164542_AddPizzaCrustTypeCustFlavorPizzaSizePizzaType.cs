using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaPros.DataAccess.Migrations
{
    public partial class AddPizzaCrustTypeCustFlavorPizzaSizePizzaType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PizzaCrustFlavor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrustFlavor = table.Column<string>(nullable: false),
                    CrustFlavorDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaCrustFlavor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaCrustType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrustType = table.Column<string>(nullable: false),
                    CrustTypeDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaCrustType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaSize",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaSize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ToppingOne = table.Column<string>(nullable: true),
                    ToppingTwo = table.Column<string>(nullable: true),
                    ToppingThree = table.Column<string>(nullable: true),
                    ToppingFour = table.Column<string>(nullable: true),
                    ToppingFive = table.Column<string>(nullable: true),
                    ToppingSix = table.Column<string>(nullable: true),
                    ToppingSeven = table.Column<string>(nullable: true),
                    ToppingEight = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    ToppingTypeId = table.Column<int>(nullable: false),
                    PizzaCrustTypeId = table.Column<int>(nullable: false),
                    PizzaCrustId = table.Column<int>(nullable: true),
                    PizzaCrustFlavorId = table.Column<int>(nullable: false),
                    PizzaSizeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaType_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaType_PizzaCrustType_PizzaCrustFlavorId",
                        column: x => x.PizzaCrustFlavorId,
                        principalTable: "PizzaCrustType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaType_PizzaCrustType_PizzaCrustId",
                        column: x => x.PizzaCrustId,
                        principalTable: "PizzaCrustType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PizzaType_PizzaSize_PizzaSizeId",
                        column: x => x.PizzaSizeId,
                        principalTable: "PizzaSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaType_ToppingType_ToppingTypeId",
                        column: x => x.ToppingTypeId,
                        principalTable: "ToppingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaType_CategoryId",
                table: "PizzaType",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaType_PizzaCrustFlavorId",
                table: "PizzaType",
                column: "PizzaCrustFlavorId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaType_PizzaCrustId",
                table: "PizzaType",
                column: "PizzaCrustId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaType_PizzaSizeId",
                table: "PizzaType",
                column: "PizzaSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaType_ToppingTypeId",
                table: "PizzaType",
                column: "ToppingTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaCrustFlavor");

            migrationBuilder.DropTable(
                name: "PizzaType");

            migrationBuilder.DropTable(
                name: "PizzaCrustType");

            migrationBuilder.DropTable(
                name: "PizzaSize");
        }
    }
}
