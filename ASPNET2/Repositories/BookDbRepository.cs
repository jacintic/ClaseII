using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET2.Repositories;

public class BookDbRepository : IBookRepository
{
    // attrs
    // attr
    private AppDbContext Context;
    private ICategoryRepository CategoryRepo;
    public BookDbRepository(AppDbContext context, ICategoryRepository categoryRepository)
    {
        Context = context;
        this.CategoryRepo = categoryRepository;
    }

    // methods
    public Book FindById(int id)
    {
        return Context.Books.Find(id);
    }

    public Book FindByIdWithAssociations(int id)
    {
        return 
            Context.Books
            .Include(b => b.Categories)
            .Include(b => b.Author)
            .Where(b => b.Id == id)
            .First();
    }

    public List<Book> FindByAuthorId(int id)
    {
        return Context.Books
            .Where(b => b.AuthorId == id)
            .ToList();
    }

    public List<Book> FindAll()
    {
        return Context.Books.ToList();
    }


    public List<Book> FindByTitleContains(string title)
    {
        return Context.Books
                .Where
                (
                    b => b.Title.ToLower()
                    .Contains(title.ToLower())
                )
                .ToList();
    }

    public List<Book> FindByPriceLowerThan(double price)
    {
        throw new NotImplementedException();
    }


    public Book Create(Book book)
    {
        if (book.Id > 0)
            return Update(book);
        if (book.Categories != null && book.Categories.Count > 0)
            Context.Categories.AttachRange(book.Categories);
        Context.Books.Add(book);
        Context.SaveChanges();
        return book;
    }

    public Book Update(Book book)
    {
        if (book.Id == 0)
            return Create(book);
        var bookDb = FindByIdWithAssociations(book.Id);
        if (bookDb is null)
            throw new Exception("Book not found");
        // if author id
        if (book.AuthorId == 0)
            throw new Exception("Author Id can't be 0");
        
        bookDb.Title = book.Title;
        bookDb.Isbn = book.Isbn;
        bookDb.Price = book.Price;
        bookDb.ReleaseYear = book.ReleaseYear;
        bookDb.Description = book.Description;
        bookDb.AuthorId = book.AuthorId;
        // deal with category
        bookDb.Categories.Clear();
        // TODO solve updating same categories twice problem
        //  //ans
        
        //Context.Entry(bookDb).State = EntityState.Modified;

        // get category ids linked to this book
        //List<int> ids = new List<int>();
        //foreach (Category cat in book.Categories)
        //    ids.Add(cat.Id);

        // same as above but with LinQ
        List<int> ids = (from Category cat in book.Categories
                         select cat.Id).ToList();
        var categories = CategoryRepo.FindAllByIdIn(ids);
        bookDb.Categories.AddRange(categories);


        // update
        // update categories
        //Context.Books.Update(book);
        //if (book.Categories != null && book.Categories.Count > 0)
        //    Context.Categories.UpdateRange(book.Categories);
        Context.SaveChanges();

        return bookDb;
    }

    public bool Delete(int id)
    {
        Book bookToDelete = FindById(id);
        if (bookToDelete == null)
            return false;
        Context.Books.Remove(bookToDelete); // un libro puede tener: author y categories
        Context.SaveChanges();
        return true;
    }

    public BookStats CalcStats()
    {
        new BookStats { };
        throw new NotImplementedException();
    }

    public bool ExistsById(int id)
    {
        return Context.Books.Where(b => b.Id == id).Any(); 
    }
}
