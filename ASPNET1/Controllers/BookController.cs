using Microsoft.AspNetCore.Mvc;

namespace ASPNET1.Controllers;

[ApiController]
[Route("api/books")]
public class BookController
{
    // attr
    private List<Book> books;

    // const
    public BookController()
    {
        books = new List<Book> 
        {
            new Book {Id = 1, Title = "Lord of the Rings", Price = 9.99},
            new Book {Id = 2, Title = "The Ender's Game", Price = 5.60},
            new Book {Id = 3, Title = "Matrix", Price = 8.45},
        };
    }


    // https://localhost:7230/api/books/1
    [HttpGet("{id}")]
    public Book FindById(int id)
    {
        foreach (Book book in books)
            if (book.Id == id)
                return book;
        return null;
    }

    // https://localhost:7230/api/books/findall
    [HttpGet("findall")]
    public List<Book> FindAll()
    {
        return books;
    }

    // https://localhost:7230/api/books
    [HttpPost]
    public Book Create(Book book)
    {
        books.Add(book);
        return book;
    }

    // update
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
        
    }

}
