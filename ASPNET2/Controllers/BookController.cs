using ASPNET2.Models;
using Microsoft.AspNetCore.Mvc;


namespace ASPNET2.Controllers;


[ApiController]
[Route("api/books")]
public class BookController
{
    private IBookRepository BookRepo;

    public BookController(IBookRepository bookRepository)
    {
        BookRepo = bookRepository;
    }


    // API Methods
    // https://localhost:7230/api/books/1
    [HttpGet("{id}")]
    public Book FindById(int id)
    {
        return BookRepo.FindById(id);
    }


    // https://localhost:7230/api/books/findall
    [HttpGet]
    public List<Book> FindAll()
    {
        return BookRepo.FindAll();
    }

    // https://localhost:7230/api/books/title
    [HttpGet("title/{title}")]
    public List<Book> FindByTitleContains(string title)
    {
        return BookRepo.FindByTitleContains(title);
    }

    [HttpGet("include/{id}")]
    public Book FindByIdWithAssociations(int id)
    {
        return BookRepo.FindByIdWithAssociations(id);
    }

    // extra methods
    // https://localhost:7230/api/books/findall
    [HttpGet("author/{id}")]
    public List<Book> FindByAuthor(int id)
    {
        return BookRepo.FindByAuthorId(id);
    }


    // https://localhost:7230/api/books
    [HttpPost]
    public Book Create(Book book)
    {
        return BookRepo.Create(book);
    }

    // update
    // https://localhost:7230/api/books
    [HttpPut]
    public Book Update(Book book)
    {
        return BookRepo.Update(book);
    }

    

    // delete
    // https://localhost:7230/api/books/1
    [HttpDelete("{id}")]
    public void DeleteById(int id)
    {
        BookRepo.Delete(id);

    }


}
