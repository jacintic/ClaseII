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
/*

// // address + country + langs

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

// interface greetings
IGreeting greeting = new FormalGreeting();

// address data
Customer customer1 = new Customer
{
    Dni = "123",
    Name = "Gumersindo",
    Email = "a@b.com",
    Address = location,
    Greeting = greeting
};

Console.WriteLine(customer1);
customer1.Greet();
customer1.Greeting = new InformalGreeting();
customer1.Greet();
Console.WriteLine(customer1.Greeting.Greet("Manolo"));

*/

// // COMPUTER

// 1. Crear clase Computer
// 2. Crear una interface IComputerRepository con operaciones CRUD sobre una lista de Computer
// 3. Crear una implementación de la interface
// 4. Utilizar los métodos desde Program.cs

IComputerRepository ComputerRepo = new ComputerListRepository();

// find all
Console.WriteLine("// Find all //");
List<Computer> CompList = ComputerRepo.FindAll();
Console.WriteLine(ComputerRepo.PrintComputerList(CompList));


// Find by id
Console.WriteLine("\n\n// Find by Id: 2 //");
Console.WriteLine(ComputerRepo.FindOneById(2));

// get id list 
Console.WriteLine("\n\n// Get Computers by ID {2,3} //");
List<Computer> CompList2 = ComputerRepo.GetByIds(new int[] { 2, 3 });
Console.WriteLine(ComputerRepo.PrintComputerList(CompList2));

// recuperar por  minimo y maximo de Ram
Console.WriteLine("\n\n// Get COmputers by ID {2,3} //");
List<Computer> CompList3 = ComputerRepo.FindAllByRamRange(16, 32);
Console.WriteLine(ComputerRepo.PrintComputerList(CompList3));

// buscar por su Modelo
Console.WriteLine("\n\n// Get Computers by Model (Asus A55A) //");
Computer CompByModel = ComputerRepo.FindOneByModel("Asus A55A");
Console.WriteLine(CompByModel);

// create/save one
Console.WriteLine("\n\n//  // Create one computer Ids 12(new) and 1(duplicate) // //");
Computer cmp1 = new Computer
{
    Id = 12, Model = "Corsair 35D2", Ram = 64
};
Console.WriteLine("\nFirst computer transaction. Save Id= 12 (non duplicate)");
bool IsComputerSaved = ComputerRepo.Save(cmp1);
Console.WriteLine("Transaction Status: " + (IsComputerSaved ? "Success" : "No computer Saved"));
Console.WriteLine("// Find by Id: 12 //");
Console.WriteLine(ComputerRepo.FindOneById(12));
// // second computer with duplicate Id
Computer cmp2 = new Computer
{
    Id = 1,
    Model = "Corsair 35D2",
    Ram = 64
};
Console.WriteLine("\nSecond computer transaction. Save Id= 1 (duplicate)");
bool IsComputerSaved2 = ComputerRepo.Save(cmp2);
Console.WriteLine("Transaction Status: " + (IsComputerSaved2 ? "Success" : "No computer Saved"));
Console.WriteLine("// Find by Id: 1 //");
Console.WriteLine(ComputerRepo.FindOneById(1));


// crear
    // case 1
Console.WriteLine("\n\n// Add computers to repo Success + All rows added //");
int numComputersAdded = ComputerRepo.AddComputersToRepo(new List<Computer>
        {
            new Computer { Id = 4, Model = "Dell Pro 300", Ram = 16 },
            new Computer { Id = 5, Model = "MSI Gaming Pro", Ram = 64 },
            new Computer { Id = 6, Model = "Asus 305D", Ram = 10 },
        });
Console.WriteLine("Transaction Status: " + (numComputersAdded > 0 ?  "Success" : "No rows added") + " Total Computers Added: " + numComputersAdded + " of " + 3); ;
Console.WriteLine(ComputerRepo.PrintAll());
    // case 2
Console.WriteLine("\n// Add computers to repo Success + Not all rows added //");
int numComputersAdded2 = ComputerRepo.AddComputersToRepo(new List<Computer>
        {
            new Computer { Id = 7, Model = "Asus 2500 3X", Ram = 64 },
            new Computer { Id = 8, Model = "Corsair DG5", Ram = 10 },
            // NOTICE: Invalid computers
            // // id exists
            new Computer { Id = 1, Model = "HP MX 300", Ram = 16 },
            // // id = 0
            new Computer { Id = 0, Model = "Computer Should fial", Ram = 10 },
            // // ram = 2
            new Computer { Id = 35, Model = "Computer Should fial", Ram = 2 },
            new Computer { Id = 35, Model = "Computer Should fial", Ram = 256 },
            // // model 3 leters
            new Computer { Id = 67, Model = "123", Ram = 2 },
            // model  null
            new Computer { Id = 67, Model = null, Ram = 2 },
            // model empty
            new Computer { Id = 67, Model = "", Ram = 2 },
        });
Console.WriteLine("Transaction Status: " + (numComputersAdded2 > 0 ? "Success" : "No rows added") + " Total Computers Added: " + numComputersAdded2 + " of " + 9); ;
Console.WriteLine(ComputerRepo.PrintAll());

// modificar
Console.WriteLine("\n\n// Modify Computer //");
bool UpdateWasSuccessful = ComputerRepo.UpdateComputerRamFromRepo(4,32);
Console.WriteLine("Transaction Status: " + (UpdateWasSuccessful ? "Success" : "No computer Updated"));
Console.WriteLine("Checking computer update, initial RAM value was 16, new one was 32");
Console.WriteLine(ComputerRepo.FindOneById(4));
// modificar
Console.WriteLine("\n// Modify Computer II (from Computer object) //");
bool UpdateWasSuccessfulII = ComputerRepo.UpdateComputer(new Computer { Id = 1, Model = "Asus Pro 3500X", Ram = 32});
Console.WriteLine("Transaction Status: " + (UpdateWasSuccessfulII ? "Success" : "No computer Updated"));
Console.WriteLine("Checking computer update, initial values: \n  Id = 1, Model = MacBook Pro, Ram = 16" +
    "\n New Values: \nId = 1, Model =Asus Pro 3500X, Ram = 32");
Console.WriteLine(ComputerRepo.FindOneById(1));



// find compuer LIKE
Console.WriteLine("\n\n// Get COmputers by model LIKE  string//");
List<Computer> CompListLike = ComputerRepo.ComputerModelIsLike("Asus");
Console.WriteLine(ComputerRepo.PrintComputerList(CompListLike));

// add prices
Console.WriteLine("\n\n//  Insert Price attribute and its prices //");
double[] PriceList = new double[9] {
        1500.00,
        1750.00,
        750.00,
        2500.00,
        2650.00,
        1700.00,
        1000.00,
        2300.00,
        1500.00,
    };
ComputerRepo.AddPrices(PriceList);
Console.WriteLine(ComputerRepo.PrintAll());

// print total price of Repo
Console.WriteLine("\n\n// Print total price of Repo //");
Console.WriteLine($"Total price of repo: {ComputerRepo.CalcPriceOfRepo()}");


// print average ram from repo
Console.WriteLine("\n\n// Print Average Ram from Repo //");
Console.WriteLine($"Average RAM of repo: {ComputerRepo.CalcAverageRamFromAllRepo()}");

// print Max Ram from Repo
Console.WriteLine("\n\n// Print Max Ram from Repo //");
Console.WriteLine($"Max RAM of repo: {ComputerRepo.FindMaxRam()}");

// print Min Ram from Repo
Console.WriteLine("\n\n// Print Min Ram from Repo //");
Console.WriteLine($"Min RAM of repo: {ComputerRepo.FindMinRam()}");

// -- NOTICE --//
// computers getting deleted beyond this point

//borrar por ids
Console.WriteLine("\n\n// Delete computers from Repo by ID List {4,6}//");
int TotalDeletions = ComputerRepo.DeleteFromIdList(new List<int> { 4,6});
Console.WriteLine("Checking delete by Id transaction status");
Console.WriteLine("Transaction Status: " + (TotalDeletions == 2 ? "Success" : "No rows deleted OR not all rows deleted. Number of rows deleted: " + TotalDeletions + " of " + 2));
Console.WriteLine("// Find all //");
Console.WriteLine(ComputerRepo.PrintAll());

// borrar todos
Console.WriteLine("\n\n// Delete all computers from repo//");
bool DeleteAllWasSuccessful = ComputerRepo.DeleteAll();
Console.WriteLine("Checking delete all transaction status");
Console.WriteLine("Transaction Status: " + (DeleteAllWasSuccessful ? "Success" : "No rows deleted"));
Console.WriteLine("// Find all //");
List<Computer> CompList5 = ComputerRepo.FindAll();
Console.WriteLine(ComputerRepo.PrintAll());
Console.WriteLine("");



