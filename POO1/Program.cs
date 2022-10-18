// instance a class

using POO1;
using System.Net;
using System.Xml.Linq;

Employee employee = new Employee("1234", "Manolo", "Perez Gomez", 27, 1500.50, true);
Employee employee2 = new Employee { Dni = "123", Name = "Juan"}; // utilizing empty constructor

// vehicle
Vehicle vehicle = new Vehicle() { Manufacturer = "Prosche", Model = "GT2 RS"};
Vehicle vehicle2 = new Vehicle() { Manufacturer = "Prosche", Model = "GT4 RS" , CubicCentimeters = 1.2F};

vehicle.Start();
vehicle.Accelerate(10);
vehicle.Accelerate(30);
vehicle.ReduceVelocity(45);
vehicle.ReduceVelocity(40);
vehicle.Accelerate(120);
vehicle.Accelerate(30);
