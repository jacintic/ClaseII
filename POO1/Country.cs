using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public class Country
{
    // attributes
    public string CountryName;
    public string Capital;
    public float Surface;
    public string[] Languages;
    public string MainLanguage;
    // constructor
    public Country() { }

    public override string ToString()
    {
        return $"Country data: {CountryName}";
    }


}
