using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmDB.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    DirectorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Movies_Director_DirectorID",
                        column: x => x.DirectorID,
                        principalTable: "Director",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "ID", "Bio", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Temp", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/13/George_Miller_%2835706244922%29.jpg/800px-George_Miller_%2835706244922%29.jpg", "George Miller" },
                    { 2, "Temp", "https://en.wikipedia.org/wiki/File:Shawn_Levy_by_Gage_Skidmore_2.jpg", "Shawn Levy" },
                    { 3, "Temp", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/David_Leitch_by_Gage_Skidmore_2.jpg/330px-David_Leitch_by_Gage_Skidmore_2.jpg", "David Leitch" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "Description", "DirectorID", "Genre", "Image", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Temp", 1, "Action", "https://m.media-amazon.com/images/M/MV5BNmYzMWVjNmQtNjJjNy00M2Y4LTkzZjQtZWQ5NmYzMjRjMDIzXkEyXkFqcGdeQXVyMTM1NjM2ODg1._V1_FMjpg_UY576_.jpg", "Furiosa: A Mad Max Saga", 2024 },
                    { 2, "Temp", 2, "Action", "https://m.media-amazon.com/images/M/MV5BN2YxYTFmYTMtZjQ0YS00YTViLTg2OWEtMmM5YzY0YTE4OTU5XkEyXkFqcGdeQXVyMTY3ODkyNDkz._V1_FMjpg_UY720_.jpg", "Deadpool & Wolverine", 2024 },
                    { 3, "Temp", 3, "Action", "https://m.media-amazon.com/images/M/MV5BMjA5ZjA3ZjMtMzg2ZC00ZDc4LTk3MTctYTE1ZTUzZDIzMjQyXkEyXkFqcGdeQXVyMTM1NjM2ODg1._V1_FMjpg_UY720_.jpg", "Fall Guy", 2024 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorID",
                table: "Movies",
                column: "DirectorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Director");
        }
    }
}
