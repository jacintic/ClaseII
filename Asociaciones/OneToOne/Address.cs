using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asociaciones.OneToOne;

public class Address
{

    // attr
    public long Id;
    public string Street;
    public string City;


    // associations
    public Customer Customer;

    // constructor
    public Address() { }

    // ToString
    public override string ToString()
    {
        return $"Id: {Id}, Street: {Street}, City: {City}";
    }
}
