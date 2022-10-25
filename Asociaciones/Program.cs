using Asociaciones.OneToOne;
using Asociaciones.ManyToOne;
using Asociaciones.ManyToMany;

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


Console.WriteLine("========= Many To Many =========");

Film film1 = new Film { Id = 1, Title = "Titanic", Duration = 1 };
Film film2 = new Film { Id = 2, Title = "Cube", Duration = 2 };
Film film3 = new Film { Id = 3, Title = "Hell Raiser", Duration = 1 };

Category category1 = new Category { Id = 1, Name = "Horror", Color = "Red"};
Category category2 = new Category { Id = 2, Name = "Romance", Color = "Purple" };
Category category3 = new Category { Id = 3, Name = "Dramma", Color = "Gray" };

film1.Categories.Add(category1);
film2.Categories.Add(category1);
film3.Categories.AddRange(new List<Category>{ category2, category3});

category1.Films.AddRange(new List<Film> { film2, film3 });
category2.Films.Add(film1);
category3.Films.Add(film1);

Console.WriteLine(film1);
Console.WriteLine(film2);
Console.WriteLine(film3);
Console.WriteLine(category1);
Console.WriteLine(category2);
Console.WriteLine(category3);