using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public class Address
{
    // address related attributes
    public string Street;
    public string PostalCode;
    public string City;
    public Country Country;

    public Address()
    {
    }

    public override string ToString()
    {
        return "Address Data:\n" +   
            $"City: {City}\n" +
            $"PostalCode: {PostalCode}\n" +
            $"Street: {Street}\n" + 
            Country;
    }
}
