namespace ASPNET2.Services;

public interface IBookService
{
    // CRUD
    Book FindById(int id);

    Book FindByIdWithAssociations(int id);

    List<Book> FindByTitleContains(string title);

    List<Book> FindByPriceLowerThan(double price);

    List<Book> FindByAuthorId(int id);

    List<Book> FindAll();

    Book Create(Book book);

    Book Update(Book book);

    bool Delete(int id);

    // CALC
    BookStats CalcStats();
    Book Publish(int id);
    void  PublishAllByAuthorId(int id);
    List<Book> FetchFromFakeApi();

    IDictionary<string, List<Book>> GroupByCategory();
}
