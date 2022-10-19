using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public class SmartPhone
{
    // attr
    public string Manufacturer;
    public int Ram;
    public int Cores;
    public string PhoneNumber;

    // empty constructor
    public SmartPhone() { }

    // auto generated constructor (quick options)


    // toString
    public override string ToString()
    {
        return $"Mobile phone data:\n" +
            $"Manufacturer: {Manufacturer}\n" +
            $"Ram: {Ram}\n" +
            $"Cores: {Cores}\n" +
            $"Number: {PhoneNumber}";
    }

}
