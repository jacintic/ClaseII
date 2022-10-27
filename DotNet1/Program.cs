Console.WriteLine("Welcome");

//SaveList();

//IsbnValidationsFail();

//IsbnValidationsSuccessl();

FindFirst();
FindSecond();

void SaveOne()
{
    var context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine("============= Save One =============");
    Book book1 = new Book { Isbn = "11111", Title = "Don Quijote de la Mancha", ReleaseYear = 1850, Description = "asdasd" };
    Book book2 = new Book { Isbn = "11112", Title = "La Celestina", ReleaseYear = 1850, Description = "asdasd" };

    context.Books.AddRange(book1, book2);

    context.SaveChanges();

    Console.WriteLine(book1 + "\n" + book2);
}
void SaveList()
{
    var context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine("============= Save List =============");
    Book book3 = new Book { Isbn = "11113", Title = "The Ender's Game", ReleaseYear= 1850, Description ="asdasd" };
    Book book4 = new Book { Isbn = "11114", Title = "Matrix", ReleaseYear = 1850, Description = "asdasd" };

    List<Book> books1 = new List<Book> { book3, book4 };

    context.Books.AddRange(books1);

    context.SaveChanges();

    Console.WriteLine(book3 + "\n" + book4);
}

void IsbnValidationsFail()
{
    var context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine("============= Isbn Validations =============");
    Book book = new Book { Isbn = "1234567", Title = "asdasdasdasdasdasdadasd", ReleaseYear = 1990, Description = "A nice book" };
    context.Books.Add(book);
    context.SaveChanges();
}

void IsbnValidationsSuccessl()
{
    var context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine("============= Isbn Validations =============");
    Book book = new Book { Isbn = "123456", Title = "asdasdasdasdasdasdadasd", ReleaseYear = 1990, Description = "A nice book" };
    context.Books.Add(book);
    context.SaveChanges();
}

void FindFirst()
{
    var context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine("============= Find first =============");
    //context.Books.First(b => b.Id == 1);
    var book = context.Books.First();
    Console.WriteLine(book);  
}

void FindSecond()
{
    var context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine("============= Find second =============");
    var book = context.Books.First(b => b.Id == 2);
    Console.WriteLine(book);
}
