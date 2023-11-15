using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ejercicio2.Migrations
{
    public partial class tablasYSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    genreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Genre_genreId",
                        column: x => x.genreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Genero con violencia y sangre", "guerra" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Genero con paisajes, varios mundos, mundo abierto.", "aventura" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Genero en el cual tiene violencia, puede contener sangre.", "lucha" });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Description", "Name", "genreId" },
                values: new object[,]
                {
                    { 1, "Juego de guerra del futuro", "Terminator 1", 1 },
                    { 2, "Juego de guerra del futuro", "Terminator 2", 1 },
                    { 3, "Juego de guerra del futuro", "Terminator 3", 1 },
                    { 4, "Juego de entretenimiento en varios mundo, el cual se lucha contra monstruos", "Super Mario Bross", 2 },
                    { 5, "Juego de entretenimiento en varios mundo, el cual se lucha contra monstruos", "Super Mario Bross", 2 },
                    { 6, "Juego de entretenimiento en varios mundo, el cual se lucha contra monstruos", "Super Mario Bross", 2 },
                    { 7, "Juego de lucha", "Tekken 6", 3 },
                    { 8, "Juego de lucha", "Tekken 7", 3 },
                    { 9, "Juego de lucha", "Tekken 8", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_genreId",
                table: "Game",
                column: "genreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
