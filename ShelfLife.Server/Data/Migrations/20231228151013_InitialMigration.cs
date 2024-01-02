using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShelfLife.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    PublicationYear = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfPages = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfChapters = table.Column<int>(type: "INTEGER", nullable: false),
                    CoverImage = table.Column<string>(type: "TEXT", nullable: false),
                    Link = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CoverImage", "Genre", "Link", "NumberOfChapters", "NumberOfPages", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, "J. R. R. Tolkien", "https://upload.wikimedia.org/wikipedia/en/8/8e/The_Fellowship_of_the_Ring_cover.gif", "Fantasy", "https://en.wikipedia.org/wiki/The_Lord_of_the_Rings", 62, 1178, 1954, "The Lord of the Rings" },
                    { 2, "J. R. R. Tolkien", "https://upload.wikimedia.org/wikipedia/en/3/30/Hobbit_cover.JPG", "Fantasy", "https://en.wikipedia.org/wiki/The_Hobbit", 19, 310, 1937, "The Hobbit" },
                    { 3, "J. R. R. Tolkien", "https://upload.wikimedia.org/wikipedia/en/0/0b/The_Silmarillion_%28J.R.R._Tolkien%29_cover.jpg", "Fantasy", "https://en.wikipedia.org/wiki/The_Silmarillion", 24, 365, 1977, "The Silmarillion" },
                    { 4, "J. R. R. Tolkien", "https://upload.wikimedia.org/wikipedia/en/9/9c/The_Children_of_H%C3%BArin_cover.jpg", "Fantasy", "https://en.wikipedia.org/wiki/The_Children_of_H%C3%BArin", 23, 313, 2007, "The Children of Húrin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
