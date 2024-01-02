using Microsoft.EntityFrameworkCore;

namespace ShelfLife.Server.Data
{
    internal static class BookRepository
    {

        internal async static Task<Book[]> GetBooksAsync()
        {
            using AppDBContext context = new();
            return await context.Books.ToArrayAsync();
        }

        internal async static Task<Book> GetBookAsync(int id)
        {
            using AppDBContext context = new();
            return await context.Books.FindAsync(id);
        }

        internal async static Task<int[]> GetAllPublicationYearsAsync()
        {
            using AppDBContext context = new();
            return await context.Books.Select(b => b.PublicationYear).Distinct().ToArrayAsync();
        }

        internal async static Task<string[]> GetAllGenresAsync()
        {
            using AppDBContext context = new();
            return await context.Books.Select(b => b.Genre).Distinct().ToArrayAsync();
        }

        internal async static Task<bool> AddBookAsync(Book book)
        {
            try
            {
                using AppDBContext context = new();
                await context.Books.AddAsync(book);
                return await context.SaveChangesAsync() >= 1; 
            } catch(Exception ex)
            {
                return false;
            }
        }

        internal async static Task<bool> UpdateBookAsync(Book book)
        {
            try
            {
                using AppDBContext context = new();
                context.Books.Update(book);
                return await context.SaveChangesAsync() >= 1;
            } catch(Exception ex)
            {
                return false;
            }
        }
        
        internal async static Task<bool> DeleteBookAsync(int id)
        {
            try
            {
                using AppDBContext context = new();
                Book book = await context.Books.FindAsync(id);
                context.Books.Remove(book);
                return await context.SaveChangesAsync() >= 1;
            } catch(Exception ex)
            {
                return false;
            }
        }

        internal async static Task<bool> DeleteAllBooksAsync()
        {
            try
            {
                using AppDBContext context = new();
                context.Books.RemoveRange(context.Books);
                return await context.SaveChangesAsync() >= 1;
            } catch(Exception ex)
            {
                return false;
            }
        }

        internal async static Task<Book[]> SearchBooksByTitleAsync(string title)
        {
            using AppDBContext context = new();
            return await context.Books.Where(b => b.Title.Contains(title)).ToArrayAsync();
        }

        internal async static Task<Book[]> SearchBooksByAuthorAsync(string author)
        {
            using AppDBContext context = new();
            return await context.Books.Where(b => b.Author.Contains(author)).ToArrayAsync();
        }

        internal async static Task<Book[]> SearchBooksByGenreAsync(string genre)
        {
            using AppDBContext context = new();
            return await context.Books.Where(b => b.Genre.Contains(genre)).ToArrayAsync();
        }

        internal async static Task<Book[]> SearchBooksByPublicationYearAsync(int publicationYear)
        {
            using AppDBContext context = new();
            return await context.Books.Where(b => b.PublicationYear == publicationYear).ToArrayAsync();
        }
    }
}
