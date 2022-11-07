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
    [HttpGet("findall")]
    public List<Book> FindAll()
    {
        return BookRepo.FindAll();
    }

    // https://localhost:7230/api/books
    [HttpPost]
    public Book Create(Book book)
    {
        return BookRepo.Create(book);
    }

    /*// update
    // https://localhost:7230/api/books
    [HttpPut]
    public Book Update(Book book)
    {
        Book bookFormDb = FindById(book.Id);
        // comprobar si existe
        if (bookFormDb is null)
            return null;
        // modificar
        bookFormDb.Title = book.Title;
        bookFormDb.Price = book.Price;
        // sustituir el original por este
        return book;
    }

    // delete
    // https://localhost:7230/api/books/1
    [HttpDelete("{id}")]
    public void DeleteById(int id)
    {
        Book bookFormDb = FindById(id);
        for (int i = 0; i < books.Count; i++)
            if (books[i].Id == id)
                books.RemoveAt(i);

    }*/
}
