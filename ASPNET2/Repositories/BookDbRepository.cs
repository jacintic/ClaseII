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
    public BookDbRepository(AppDbContext context)
    {
        Context = context;
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
        // if category id
        //foreach (Category category in book.Categories)
        //    if (category.Id == 0)
        //        throw new Exception("Category  Idcan't be 0");
        // update categories as well
        //if (book.Categories != null && book.Categories.Count > 0)
        //    Context.Categories.AttachRange(book.Categories);
        
        //Context.Books.Attach(book);
        //// guardar solo attributes que interesen
        //Context.Entry(book).Property(b => b.Title).IsModified = true;
        //Context.Entry(book).Property(b => b.Description).IsModified = true;
        //Context.Entry(book).Property(b => b.AuthorId).IsModified = true;
        //Context.Entry(book).Property(b => b.Isbn).IsModified = true;
        //Context.Entry(book).Property(b => b.ImgUrl).IsModified = true;
        //Context.Entry(book).Property(b => b.Price).IsModified = true;
        //Context.Entry(book).Property(b => b.ReleaseYear).IsModified = true;
        //Context.Entry(book).Collection(b => b.Categories).IsModified = true;
        
        bookDb.Title = book.Title;
        bookDb.Isbn = book.Isbn;
        bookDb.Price = book.Price;
        bookDb.ReleaseYear = book.ReleaseYear;
        bookDb.Description = book.Description;
        bookDb.AuthorId = book.AuthorId;
        // deal with category
        bookDb.Categories.Clear();
        bookDb.Categories = book.Categories;
        // TODO solve updating same categories twice problem
        //  //ans
        foreach (Category category in book.Categories)
            bookDb.Categories.Add(Context.Categories.Find(category.Id));
        //Context.Entry(bookDb).State = EntityState.Modified;


        // update
        // update categories
        //Context.Books.Update(book);
        //if (book.Categories != null && book.Categories.Count > 0)
        //    Context.Categories.UpdateRange(book.Categories);
        Context.SaveChanges();

        return FindById(bookDb.Id);
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
}
