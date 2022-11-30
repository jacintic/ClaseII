using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTesting.Repositories;

public class BookDbRepositoryTest
{
    [Fact]
    public void FindAllTest()
    {
        AppDbContext context = CreateContext();



        Book b1 = new() { Title = "Book 1", Description = "Desc 1", Isbn = "12345", ReleaseYear = 12345 };
        Book b2 = new() { Title = "Book 2", Description = "Desc 2", Isbn = "12345", ReleaseYear = 12345 };
        
        context.Books.AddRange(new List<Book> { b1, b2});
        context.SaveChanges();

        IBookRepository bookRepo = CreateRepository(context);
        List<Book> books = bookRepo.FindAll();

        Assert.NotEmpty(books);
        Assert.Equal(2, books.Count());
        context.Dispose();
    }

    private static IBookRepository CreateRepository(AppDbContext context)
    {
        ICategoryRepository catRepo = new CategoryDbRepository(context);
        IBookRepository bookRepo = new BookDbRepository(context, catRepo);
        return bookRepo;
    }
    private AppDbContext CreateContext()
    {
        // create MySQL DB setting
        string url = "server=localhost;port=3306;user=root;password=admin;database=cursonet";
        var options = new DbContextOptionsBuilder<AppDbContext>()
                        .UseMySql(url, ServerVersion.AutoDetect(url))
                        .Options;
        AppDbContext context = new AppDbContext(options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.SaveChanges();

        return context;
    }
}
