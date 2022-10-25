using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asociaciones.ManyToMany;

// many categories to many films
public class Category
{
    public long Id;
    public string Name;
    public string Color;

    public List<Film> Films = new List<Film>();

    public Category() { }


    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Color: {Color}, Films: {Films.Count}";
    }

}
