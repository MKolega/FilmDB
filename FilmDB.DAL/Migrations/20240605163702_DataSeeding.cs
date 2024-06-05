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
                name: "Movies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "Description", "Director", "Genre", "Image", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Temp", "George Miller", "Action", "https://m.media-amazon.com/images/M/MV5BNmYzMWVjNmQtNjJjNy00M2Y4LTkzZjQtZWQ5NmYzMjRjMDIzXkEyXkFqcGdeQXVyMTM1NjM2ODg1._V1_FMjpg_UY576_.jpg", "Furiosa: A Mad Max Saga", 2024 },
                    { 2, "Temp", "Shawn Levy", "Action", "https://m.media-amazon.com/images/M/MV5BN2YxYTFmYTMtZjQ0YS00YTViLTg2OWEtMmM5YzY0YTE4OTU5XkEyXkFqcGdeQXVyMTY3ODkyNDkz._V1_FMjpg_UY720_.jpg", "Deadpool & Wolverine", 2024 },
                    { 3, "Temp", "David Leitch", "Action", "https://m.media-amazon.com/images/M/MV5BMjA5ZjA3ZjMtMzg2ZC00ZDc4LTk3MTctYTE1ZTUzZDIzMjQyXkEyXkFqcGdeQXVyMTM1NjM2ODg1._V1_FMjpg_UY720_.jpg", "Fall Guy", 2024 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
