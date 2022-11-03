using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Asociaciones.Repositories;

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
            .Where(b => b.Id == id)
            .FirstOrDefault();
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
        Context.Books.Add(book);
        Context.SaveChanges();
        return book;
    }

    public Book Update(Book book)
    {
        if (book.Id == 0)
            return Create(book);

        // guardar solo attributes que interesen
        Context.Books.Attach(book);
        Context.Entry(book).Property(b => b.Title).IsModified = true;
        Context.Entry(book).Property(b => b.AuthorId).IsModified = true;
        Context.Entry(book).Property(b => b.Categories).IsModified = true;

        Context.SaveChanges();

        return FindById(book.Id);
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
