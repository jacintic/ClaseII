using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1;

public abstract class RoadVehicle
{
    public string Manufacturer;
    public int WheelNum;
    public bool Status;
    public void Start()
    {
        Status = true;
    }
    public virtual void Stop()
    {
        Status = false;
    }
}

public abstract class Car : RoadVehicle
{
    public int DoorsNumber;
    public bool ExtraWheel;
    public int NumPassangers;
    public float Range;
    public int NumPersons;

}

public class MotorCycle : RoadVehicle
{
    public bool Copilot;
    public bool Naked;
}

public class Truck : RoadVehicle
{
    public bool Trailer;
    public int TrailerCapacity;
}

public class ElectricCar : Car
{
    public double VateryCapactiy;
    public TimeSpan RechargeTime;
}

public class ICECar : Car
{
    public double DepositCapacity;
    public string FuelType;
    public string EmissionsLevel;

    public override void Stop()
    {
        base.Stop();
        NumPersons = 0;
    }
}