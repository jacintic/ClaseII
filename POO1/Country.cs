using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public class Country
{
    // attributes
    public string? CountryName;
    public string? Capital;
    public float? Surface;
    public List<Language>? Languages;
    public Language? MainLanguage;
    // constructor
    public Country() { }

    // methods

    public void InitializeList()
    {
        Languages = new List<Language>();
    }
    public void AddLangToList(Language lang)
    {
        Languages.Add(lang);

    }

    public string PrintLangs()
    {
        string list = "\n";
        Languages.ForEach(l => list += "\t. " + l + "\n");
        return list;
    }
    public override string ToString()
    {
        return $"Country data: {CountryName}\n" +
            $"Main language: {MainLanguage}\n" +
            $"Languages spoken in country: {PrintLangs()}";
    }
}
