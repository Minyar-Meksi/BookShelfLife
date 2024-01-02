using ShelfLife.Server.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new() { Title = "ShelfLife", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "ShelfLife API";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "ShelfLife API v1");
    swaggerUIOptions.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");


app.MapGet("/books/getAllYears", async () => await BookRepository.GetAllPublicationYearsAsync())
    .WithTags("Books Endpoints");

app.MapGet("/books/getAllGenres", async () => await BookRepository.GetAllGenresAsync())
    .WithTags("Books Endpoints");

app.MapGet("/books/", async () => await BookRepository.GetBooksAsync())
    .WithTags("Books Endpoints");

app.MapGet("/books/{id}", async (int id) => 
{
   Book book = await BookRepository.GetBookAsync(id);
    if (book is null)
    {
         return Results.NotFound();
    }
    return Results.Ok(book);
}).WithTags("Books Endpoints");

app.MapPost("/books/", async (Book book) => 
{
    bool isCreated = await BookRepository.AddBookAsync(book);
    if (isCreated)
    {
        return Results.Created($"/books/{book.Id}", book);
    }
    return Results.BadRequest();
}).WithTags("Books Endpoints");

app.MapPut("/books/", async (Book book) => 
{
    bool isUpdated = await BookRepository.UpdateBookAsync(book);
    if (isUpdated)
    {
        return Results.Ok(book);
    }
    return Results.BadRequest();
}).WithTags("Books Endpoints");

app.MapDelete("/books/{id}", async (int id) =>
{
    bool isDeleted = await BookRepository.DeleteBookAsync(id);
    if (isDeleted)
    {
        return Results.Ok("Delete was successful.");
    }
    return Results.BadRequest();
}).WithTags("Books Endpoints"); 

app.MapDelete("/books/", async () =>
{
    bool isDeleted = await BookRepository.DeleteAllBooksAsync();
    if (isDeleted)
    {
        return Results.Ok("All books deleted.");
    }
    return Results.BadRequest();
}).WithTags("Books Endpoints");

app.MapGet("/books/search/title/{title}", async (string title) =>
{
    Book[] books = await BookRepository.SearchBooksByTitleAsync(title);
    if (books.Length == 0)
    {
        return Results.NotFound("No books found for that title.");
    }
    return Results.Ok(books);
}).WithTags("Search Books Endpoints");

app.MapGet("/books/search/author/{author}", async (string author) =>
{
    Book[] books = await BookRepository.SearchBooksByAuthorAsync(author);
    if (books.Length == 0)
    {
        return Results.NotFound("No books found for that author.");
    }
    return Results.Ok(books);
}).WithTags("Search Books Endpoints");

app.MapGet("/books/search/genre/{genre}", async (string genre) =>
{
    Book[] books = await BookRepository.SearchBooksByGenreAsync(genre);
    if (books.Length == 0)
    {
        return Results.NotFound("No books found for that genre.");
    }
    return Results.Ok(books);
}).WithTags("Search Books Endpoints");

app.MapGet("/books/search/year/{year}", async (int year) =>
{
    Book[] books = await BookRepository.SearchBooksByPublicationYearAsync(year);
    if (books.Length == 0)
    {
        return Results.NotFound("No books found for that year.");
    }
    return Results.Ok(books);
}).WithTags("Search Books Endpoints");

app.Run();
