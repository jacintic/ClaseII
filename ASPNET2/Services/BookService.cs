using System.Collections.Generic;

namespace ASPNET2.Services;

public class BookService : IBookService
{
    private const decimal IVA = 1.21m;
    private readonly IBookRepository BookRepository;
    private readonly IAuthorRepository AuthorRepository;

    public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository)
    {
        BookRepository = bookRepository;
        AuthorRepository = authorRepository;
    }
    //CRUD
    public Book Create(Book book)
    {
        //book.Price *= IVA;
        return BookRepository.Create(book);
    }

    public List<Book> FindAll()
    {
        return BookRepository.FindAll();
    }
    public List<Book> FindByAuthorId(int id)
    {
        if (id == 0)
            throw new Exception("Invalid ID");
        return BookRepository.FindByAuthorId(id);
    }

    public Book FindById(int id)
    {
        if (id == 0)
            throw new Exception("Invalid ID");
        return BookRepository.FindById(id);
    }

    public Book FindByIdWithAssociations(int id)
    {
        if (id == 0)
            throw new Exception("Invalid ID");
        return BookRepository.FindByIdWithAssociations(id);
    }
    public List<Book> FindByTitleContains(string title)
    {
        if (title is null || title.Length == 0)
            throw new Exception("Title is empty");
        return BookRepository.FindByTitleContains(title);
    }

    public List<Book> FindByPriceLowerThan(double price)
    {
        throw new NotImplementedException();
    }

    
    public bool Delete(int id)
    {
        return BookRepository.Delete(id);
    }

    

    
    public Book Update(Book book)
    {
        throw new NotImplementedException();
    }
    // CALC
    public BookStats CalcStats()
    {
        throw new NotImplementedException();
    }

    public Book Publish(int id)
    {
        // check exist condition
        if (!BookRepository.ExistsById(id))
            throw new Exception("Book doesn't exist");
        // FindBy Id
        Book bookFromDB = BookRepository.FindById(id);
        // change status to published
        bookFromDB.Status = BookStatus.PUBLISHED;
        // change date to current date
        bookFromDB.ReleaseYear = (int)DateTime.Now.Year;
        // return book
        return BookRepository.Update(bookFromDB);
    }

    public void PublishAllByAuthorId(int id)
    {
        if (id == 0 )
            throw new IllegalIdException("Id can't be 0 or null");
        // check if author exits
        if (BookRepository.ExistsById(id))
            throw new EntityNotFoundException("Author doesn't exist");
        // get book collection 
        List<Book> authBooks = FindByAuthorId(id);
        // check exist condition
        if (authBooks.Count <= 0)
            throw new Exception("Author doesn't have any books");
        // change status to published and update
        foreach (Book book in authBooks)
        {
            book.Status = BookStatus.PUBLISHED;
            book.ReleaseYear = (int)DateTime.Now.Year;
            BookRepository.Update(book);
        }
        // SHOULD
        //  // updateRange(books)
    }

    public List<Book> FetchFromFakeApi()
    {
        throw new NotImplementedException();
    }

    public IDictionary<string, List<Book>> GroupByCategory()
    {
        throw new NotImplementedException();
    }
}
