using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public class Customer
{
    public string Dni;
    public string Name;
    public string Email;
    public Address Address;

    public Customer()
    {
    }

    public Customer(string dni, string email, Address address)
    {
        Dni = dni;
        Email = email;
        Address = address;
    }

    public override string ToString()
    {
        return "Customer: \n" +
            $"ID: {Dni}\n" +
            $"Name: {Name}\n" +
            $"Email: {Email}\n" +
            $"{Address}";
    }

}
