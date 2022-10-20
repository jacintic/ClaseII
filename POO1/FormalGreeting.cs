using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public class FormalGreeting : IGreeting
{
    public void Greet()
    {
        Console.WriteLine("Hello there!");
    }

    public string Greet(string name)
    {
        return $"Hello there {name}!";
    }
}
