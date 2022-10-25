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
        string categoryList = "";
        foreach (Category category in Categories)
        {
            categoryList += "\n\t. " + category.Name;
        }
        return categoryList;
    }
    public override string ToString()
    {
        return $"Id: {Id}, Title: {Title}, Duration: {Duration}, Categories: {PrintCategories()}" ;
    }
}
