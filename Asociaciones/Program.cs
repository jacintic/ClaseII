using Asociaciones.OneToOne;
using Asociaciones.ManyToOne;


Console.WriteLine("========= One To One =========");

Address address = new Address { Id = 1, City = "Barcelona", Street = "Muntaner" };

Customer customer = new Customer { Id = 1, Name = "John", Age = 27, Address = address} ;

Console.WriteLine(customer);
Console.WriteLine(address);

Console.WriteLine("========= One To Many =========");
Author author = new Author { Id = 1, Name = "Peter Jhonson" };

/*
Book book1 = new Book { Id = 1, Title = "The many books I'm going to write" , Author = author };
Book book2 = new Book { Id = 2, Title = "My second book", Author = author };
*/
Book book1 = new Book { Id = 1, Title = "The many books I'm going to write"};
Book book2 = new Book { Id = 2, Title = "My second book"};
book1.Author = author;
book2.Author = author;


author.books.AddRange(new List<Book> { book1, book2});



Console.WriteLine(book1);
Console.WriteLine(book2);
Console.WriteLine(author);