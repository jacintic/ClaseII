using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public class Employee
{

    // attributes
    public string Dni;
    public string Name;
    public string? Surnames;
    public int? Age;
    public double? Salary;
    public bool? Married;

    // empty constructor
    public Employee() { }

    // 2. constructor
    public Employee(string dni, string name, string surnames, int age, double salary, bool married)
    {
        Dni = dni;
        Name = name;
        Surnames = surnames;
        Age = age; 
        Salary = salary;
        Married = married;
    }

    // supercharged constructor
    public Employee(string dni, string name)
    {
        Dni = dni;
        Name = name;
    }


    // methods
}
