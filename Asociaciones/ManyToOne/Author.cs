using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asociaciones.ManyToOne;

// One To Many
public class Author
{
    // attr
    public int Id;
    public string Name;

    // associations
    public List<Book> books;
    // constructor
    public Author() 
    { 
        books = new List<Book>();
    }

    // ToString
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}
