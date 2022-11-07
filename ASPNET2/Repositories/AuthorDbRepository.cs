using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET2.Repositories;

public class AuthorDbRepository : IAuthorRepository
{
    // attr
    private AppDbContext Context;

    // associations

    // constructor
    public AuthorDbRepository(AppDbContext context)
    {
        Context = context;
    }

    // find authro by id
    public Author FindById(int id)
    {
        return Context.Authors.Find(id);
    }

    public List<Author> FindAll()
    {
        return Context.Authors.ToList();
    }

    public Author FindByEmail(string email)
    {
        return Context.Authors
                    .Where(
                        author => author.Email.ToLower().Equals(email.ToLower()))
                    .FirstOrDefault(); // first or default avoids unhandled exception,
                                       // returns null if not found
    }

    public List<Author> FindByEmailContains(string email)
    {
        return Context.Authors
                .Where(a => EF.Functions.Like(a.Email.ToLower(), $"%{email.ToLower()}%"))
                .ToList();
    }

    public List<Author> FindByEmailContainsII(string email)
    {
        return Context.Authors
                .Where(a => a.Email.ToLower().Contains(email.ToLower()))
                .ToList();
    }

    public List<Author> FindSalGreaterThan(decimal sal) 
    {
        return Context.Authors
        .Where(author => author.Salary > sal)
        .ToList();
    }

    public Author Create(Author author)
    {
        // Si tiene id asignado entonces es un update y no creamos
        if (author.Id > 0)
            return Update(author);
        Context.Authors.Add(author);
        Context.SaveChanges();
        return author;
    }

    public Author Update(Author author)
    {
        if (author.Id == 0)
            return Create(author);
        Author authorEntity = FindById(author.Id);
        if (authorEntity == null)
            return null;
        authorEntity.Email = author.Email;
        authorEntity.FullName = author.FullName;
        authorEntity.Salary = author.Salary;

        Context.Authors.Update(authorEntity);

        Context.SaveChanges();

        return authorEntity;
    }

    public bool Remove(int id)
    {
        Author authToDelete = FindById(id);
        if (authToDelete == null)
            return false;
        Context.Authors.Remove(authToDelete);
        Context.SaveChanges();
        return true;
    }
}
