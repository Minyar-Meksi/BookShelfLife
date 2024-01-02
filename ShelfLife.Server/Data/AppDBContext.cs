using Microsoft.EntityFrameworkCore;

namespace ShelfLife.Server.Data
{
    internal sealed class AppDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=./Data/AppDB.db");

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            Book[] books = 
            {
                new() {
                    Id = 1,
                    Title = "The Lord of the Rings",
                    Author = "J. R. R. Tolkien",
                    Genre = "Fantasy",
                    PublicationYear = 1954,
                    NumberOfPages = 1178,
                    NumberOfChapters = 62,
                    CoverImage = "https://upload.wikimedia.org/wikipedia/en/8/8e/The_Fellowship_of_the_Ring_cover.gif",
                    Link = "https://en.wikipedia.org/wiki/The_Lord_of_the_Rings"
                },
                new() {
                    Id = 2,
                    Title = "The Hobbit",
                    Author = "J. R. R. Tolkien",
                    Genre = "Fantasy",
                    PublicationYear = 1937,
                    NumberOfPages = 310,
                    NumberOfChapters = 19,
                    CoverImage = "https://upload.wikimedia.org/wikipedia/en/3/30/Hobbit_cover.JPG",
                    Link = "https://en.wikipedia.org/wiki/The_Hobbit"
                },
                new()
                {
                    Id = 3,
                    Title = "The Silmarillion",
                    Author = "J. R. R. Tolkien",
                    Genre = "Fantasy",
                    PublicationYear = 1977,
                    NumberOfPages = 365,
                    NumberOfChapters = 24,
                    CoverImage = "https://upload.wikimedia.org/wikipedia/en/0/0b/The_Silmarillion_%28J.R.R._Tolkien%29_cover.jpg",
                    Link = "https://en.wikipedia.org/wiki/The_Silmarillion"
                },
                new()
                {
                    Id = 4,
                    Title = "The Children of Húrin",
                    Author = "J. R. R. Tolkien",
                    Genre = "Fantasy",
                    PublicationYear = 2007,
                    NumberOfPages = 313,
                    NumberOfChapters = 23,
                    CoverImage = "https://upload.wikimedia.org/wikipedia/en/9/9c/The_Children_of_H%C3%BArin_cover.jpg",
                    Link = "https://en.wikipedia.org/wiki/The_Children_of_H%C3%BArin"
                },
            };

            modelBuilder.Entity<Book>().HasData(books);
        }
        
    }
}
