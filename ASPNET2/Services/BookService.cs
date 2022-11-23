namespace ASPNET2.Services;

public class BookService : IBookService
{
    //CRUD
    public Book Create(Book book)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Book> FindAll()
    {
        throw new NotImplementedException();
    }

    public List<Book> FindByAuthorId(int id)
    {
        throw new NotImplementedException();
    }

    public Book FindById(int id)
    {
        throw new NotImplementedException();
    }

    public Book FindByIdWithAssociations(int id)
    {
        throw new NotImplementedException();
    }

    public List<Book> FindByPriceLowerThan(double price)
    {
        throw new NotImplementedException();
    }

    public List<Book> FindByTitleContains(string title)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
}
