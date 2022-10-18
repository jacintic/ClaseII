using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public class Vehicle
{
    // attributes
    public string Manufacturer;
    public string Model;
    public float CubicCentimeters;
    public bool Status;
    public int Velocity;

    // constructor
    public Vehicle() { }

    // methods
    public void Start()
    {
        Status = true;
    }

    public void Stop()
    {
        Status = false;
    }

    // metodos velocidad
    // doesn't accelerate if speed + increment > 120
    public void Accelerate(int increment)
    {
        if (Velocity >= 120)
        {
            Console.WriteLine("Speed is over 120, can't accelerate");
            return;
        }
        if (Velocity + increment >  120)
        {
            Console.WriteLine("Can't accelerate that ammount, it exceeds 120 km/h limit");
            return;
        }

        Velocity += increment;
        Console.WriteLine($"Accelerated, Current speed: {Velocity}");
        /*
         * Codigo profe
         * if (increment > 0 && Velocity + increment <= 120)
         *      Velocity += increment;
         * else if (Velocity + increment > 120)
         *      Velocity = 120;
         * */
    }

    public void ReduceVelocity(int decrement)
    {
        if (Velocity == 0)
        {
            Console.WriteLine("Can't reduce speed more, it's already 0");
            return;
        }
        if (Velocity < 0)
        {
            Console.WriteLine("Something wrong with the velocity, it is below 0");
            return;
        }
        if (Velocity - decrement < 0)
        {
            Console.WriteLine("Can't decrease speed that ammount, it is below 0");
            return;
        }
        Velocity -= decrement;
        Console.WriteLine($"Decreased speed, Current speed: {Velocity}");
    }
}
