using ASPNET2.Models;
using Microsoft.AspNetCore.Mvc;


namespace ASPNET2.Controllers;


[ApiController]
[Route("api/books")]
public class BookController
{
    private readonly IBookService BookService;
    private readonly ILogger<BookController> Logger;

    public BookController(IBookService bookService, ILogger<BookController> logger)
    {
        BookService = bookService;
        Logger = logger;
    }


    // API Methods
    // https://localhost:7230/api/books/1
    [HttpGet("{id}")]
    public Book FindById(int id)
    {
        return BookService.FindById(id);
    }


    // https://localhost:7230/api/books/findall
    [HttpGet]
    public List<Book> FindAll()
    {
        return BookService.FindAll();
    }

    // https://localhost:7230/api/books/findall
    [HttpGet("postmanupdate")]
    public List<Book> FindAllII()
    {
        return BookService.FindAll();
    }

    // https://localhost:7230/api/books/title
    [HttpGet("title/{title}")]
    public List<Book> FindByTitleContains(string title)
    {
        return BookService.FindByTitleContains(title);
    }

    [HttpGet("include/{id}")]
    public Book FindByIdWithAssociations(int id)
    {
        return BookService.FindByIdWithAssociations(id);
    }

    // extra methods
    // https://localhost:7230/api/books/findall
    [HttpGet("author/{id}")]
    public List<Book> FindByAuthor(int id)
    {
        return BookService.FindByAuthorId(id);
    }

    

    // https://localhost:7230/api/books
    [HttpPost]
    public Book Create(Book book)
    {
        return BookService.Create(book);
    }

    // update
    // https://localhost:7230/api/books
    [HttpPut]
    public Book Update(Book book)
    {
        return BookService.Update(book);
    }

    

    // delete
    // https://localhost:7230/api/books/1
    [HttpDelete("{id}")]
    public void DeleteById(int id)
    {
        BookService.Delete(id);

    }

    [HttpGet("stats")]
    public BookStats CalculateStats()
    {
        return new BookStats { TotalBooks = 20, MaxPrice = 40 };
    }

    // update
    // https://localhost:7230/api/books
    [HttpGet("publish/{id}")]
    public Book Publish(int id)
    {
        return BookService.Publish(id);
    }

    [HttpGet("publish-by-author/{id}")]
    public void PublishAllByAuthor(int id)
    {
        Logger.LogInformation("Publishing all books b author id: {id}" , id);
        try
        {
            BookService.PublishAllByAuthorId(id);
            // OK
        }
        catch (EntityNotFoundException e)
        {
            // NOT FOUND
            Logger.LogError("Error: {message}", e.Message);
        }
        catch (IllegalIdException e)
        {
            // BAD REQUEST
            Logger.LogError("Error: {message}", e.Message);
        }
        catch (Exception e)
        {
            // UNKNOWN ERROR
            Logger.LogError("Error: {message}",e.Message);
        }
    }
}
