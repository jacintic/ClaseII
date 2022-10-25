using Asociaciones.OneToOne;

Console.WriteLine("========= One To One =========");

Address address = new Address { Id = 1, City = "Barcelona", Street = "Muntaner" };

Customer customer = new Customer { Id = 1, Name = "John", Age = 27, Address = address} ;

Console.WriteLine(customer);
Console.WriteLine(address);
