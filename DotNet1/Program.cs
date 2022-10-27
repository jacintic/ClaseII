Console.WriteLine("Welcome");

var context = new AppDbContextFactory().CreateDbContext(null);
/*

Book book1 = new Book { Isbn = "11111", Title = "Don Quijote de la Mancha" };
Book book2 = new Book { Isbn = "11112", Title = "La Celestina" };

context.Books.AddRange(book1, book2);

context.SaveChanges();

Console.WriteLine(book1 + "\n" + book2);

Book book3 = new Book { Isbn = "11113", Title = "The Ender's Game" };
Book book4 = new Book { Isbn = "11114", Title = "Matrix" };

List<Book> books1 = new List<Book> {book3, book4};

context.Books.AddRange(books1);

context.SaveChanges();

Console.WriteLine(book3 + "\n" + book4);
*/
Console.WriteLine("============= Required =============");
Book book5 = new Book { Isbn = "54321", Title = "" };
context.Books.Add(book5);
context.SaveChanges();