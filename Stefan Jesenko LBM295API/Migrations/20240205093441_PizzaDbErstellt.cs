using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stefan_Jesenko_LBM295API.Migrations
{
    /// <inheritdoc />
    public partial class PizzaDbErstellt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zutaten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zutat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zutaten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaZutaten",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    ZutatensId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaZutaten", x => new { x.PizzaId, x.ZutatensId });
                    table.ForeignKey(
                        name: "FK_PizzaZutaten_Pizzen_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaZutaten_Zutaten_ZutatensId",
                        column: x => x.ZutatensId,
                        principalTable: "Zutaten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaZutaten_ZutatensId",
                table: "PizzaZutaten",
                column: "ZutatensId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaZutaten");

            migrationBuilder.DropTable(
                name: "Pizzen");

            migrationBuilder.DropTable(
                name: "Zutaten");
        }
    }
}
