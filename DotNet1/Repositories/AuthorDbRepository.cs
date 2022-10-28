using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet1.Repositories;

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

    public List<Author> FindSalGreaterThan(decimal sal) 
    {
        return Context.Authors
        .Where(author => author.Salary > sal)
        .ToList();
    }
}
