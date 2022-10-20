using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public class InformalGreeting : IGreeting
{
    public void Greet()
    {
        Console.WriteLine("Hey whaddup!");
    }

    public string Greet(string name)
    {
        return $"Hey whaddup {name}!";
    }
}
