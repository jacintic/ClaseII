using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asociaciones.OneToOne;

public class Customer
{
    // attr
    public long Id; // 64
    public string Name;
    public int Age;
    
    // associations
    public Address Address;  // 1 customer 1 address one to one

    // constructors
    public Customer() { }

    // methods


    //ToString
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Age: {Age}";
    }
}
