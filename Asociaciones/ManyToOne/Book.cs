using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Asociaciones.ManyToOne;

// many books to one author
public  class Book
{
    // attr
    public int Id;
    public string Title;

    // associations
    public Author Author;
    // constructor

    // ToString
    public override string ToString()
    {
        return $"Id: {Id}, Title: {Title} Author: {Author.Name}";
    }
}
