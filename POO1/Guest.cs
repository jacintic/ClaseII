using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace POO1;

public class Guest
{
    public Guest(int age, string dni, double salary)
    {
        Age = age;
        Dni = dni;
        Salary = salary;
    }
    public Guest() { }

    //attr
    //public int Age { get; set; }
    private int Age
    {
        get { return Age; }

        set
        {
            if (value >= 18)
                Age = value;
            else
                Age = 18;
        }
    }

    public string Dni { get;}

    public double Salary 
    { 
        get; 
        private set; 
    }

    public void Promote(double quantity)
    {
        Salary += quantity;
    }

    // private methods
    public void Promote()
    {
        double quantity = CalcSalaryPromotion();
        Salary += quantity;
    }

    private double CalcSalaryPromotion()
    {
        return 100.0;
    }



}
