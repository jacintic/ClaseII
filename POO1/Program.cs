// instance a class

using POO1;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Xml.Linq;

/*
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


// tostring method
SmartPhone mobile1 = new SmartPhone { Manufacturer = "Samsung", Cores = 4, Ram = 8};

Console.WriteLine(mobile1);
*/

// getters and setters
/*
Guest invitado = new Guest();
*/

/*
// customer

Address address1 = new Address
{
    City = "Barcelona"
};

Customer customer1 = new Customer
{
    Dni = "123",
    Email = "a@b.com",
    Address = address1
};

Console.WriteLine(customer1);
*/

// Vehicles and inheritance
/*
// car
Car car = new Car();
car.Manufacturer = "Ford";  // inherited
car.WheelNum = 4;           // inherited
car.DoorsNumber = 3;
car.ExtraWheel = false;
car.NumPassangers = 3;
car.Start();                // inherited
*/

/*
// // Vehicles

// motorcycle
MotorCycle moto = new MotorCycle();
moto.Manufacturer = "Honda";    // inherited
moto.WheelNum = 2;              // inherited
moto.Naked = true;
moto.Copilot = false;
moto.Start();                   // inherited

// truck
Truck truck = new Truck();
truck.Manufacturer = "Mercedes";    // inherited
truck.WheelNum = 8;                 // inherited
truck.Trailer = true;
truck.TrailerCapacity = 4567;
moto.Start();                       // inherited

// car
ElectricCar electric1 = new ElectricCar();
electric1.Manufacturer = "Tesla";
electric1.WheelNum = 4;
electric1.DoorsNumber = 3;
electric1.ExtraWheel = true;
electric1.NumPassangers = 2;
electric1.VateryCapactiy = 5000.0;
electric1.RechargeTime = TimeSpan.Parse("0:04:30");

// override inheritance

Car coche1 = new ICECar();
coche1.NumPersons = 3;
coche1.Start();
Console.WriteLine(coche1.NumPersons + " " + coche1.Status);
coche1.Stop();
Console.WriteLine(coche1.NumPersons + " " + coche1.Status);

*/

// address + country + langs

Language lang1 = new Language { LanguageName = "Catalan" };
Language lang2 = new Language { LanguageName = "Spanish" };
Language lang3 = new Language { LanguageName = "English" };

Country country = new Country
{
    CountryName = "Spain",
    Capital = "Madrid",
    MainLanguage = lang2
};


country.InitializeList(); // without this the list won't take any inputs
country.AddLangToList(lang1);
country.AddLangToList(lang2);
country.AddLangToList(lang3);

Address location = new Address
{
    Street = "Sardenya",
    PostalCode = "08064",
    City = "Barcelona",
    Country = country
};

// address data
Customer customer1 = new Customer
{
    Dni = "123",
    Name = "Gumersindo",
    Email = "a@b.com",
    Address = location
};

Console.WriteLine(customer1);