using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public class Computer
{
    public int Id;
    public string Model;
    public int Ram;

    public Computer() { }

    public override string ToString()
    {
        return "\nComputer: "+
                    $"Id: {Id} "+
                    $"Model: {Model} "+
                    $"Ram: {Ram}";
    }
}

