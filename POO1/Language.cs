using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public class Language
{
    // attr
    public string LanguageName;
    public string? CodeISO;
    // constructor
    public Language() { }

    public override string ToString()
    {
        return  LanguageName;
    }

}
