using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefStock.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaRestaurantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Restaurante_RestauranteId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.CreateTable(
                name: "Restaurantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurantes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Restaurantes_RestauranteId",
                table: "Funcionarios",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Restaurantes_RestauranteId",
                table: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Restaurantes");

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Restaurante_RestauranteId",
                table: "Funcionarios",
                column: "RestauranteId",
                principalTable: "Restaurante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
