Console.WriteLine("Welcome");

var context = new AppDbContextFactory().CreateDbContext(null);


Book book1 = new Book { Isbn = "11111", Title = "Don Quijote de la Mancha" };
Book book2 = new Book { Isbn = "11112", Title = "La Celestina" };

context.Books.AddRange(book1, book2);

context.SaveChanges();

Console.WriteLine(book1 + "\n" + book2);

