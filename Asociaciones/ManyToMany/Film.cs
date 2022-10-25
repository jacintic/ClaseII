using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asociaciones.ManyToMany;

// many films to many categories
public class Film
{
    public long Id;
    public string Title;
    public int Duration;

    public List<Category> Categories = new List<Category>();

    public Film() { }

    private string PrintCategories()
    {
        return String.Join(" ", Categories.Select(c => $"\n\t.{c.Name}"));
    }
    public override string ToString()
    {
        return $"Id: {Id}, Title: {Title}, Duration: {Duration}, Categories: {PrintCategories()}" ;
    }
}
