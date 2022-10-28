Console.WriteLine("Welcome");

//SaveList();

//IsbnValidationsFail();

//IsbnValidationsSuccessl();

/*FindFirst();
FindSecond();
FindById(1);*/
//Count();
//Update() ;
//Update2(new Book { Id = 2, Isbn = "11111", Title = "Don Quijote de la Mancha", ReleaseYear = 1850, Description = "From Update 2" });
//UpdateMulti();
//Remove();
//RemoveRange();
//FindByTitle("Torrente");
//FindByTitle("123");


// Repositories
AppDbContext dbContext = new AppDbContextFactory().CreateDbContext(null);
IAuthorRepository authorRepo = new AuthorDbRepository(dbContext);

Console.WriteLine("Auth1:" + authorRepo.FindById(1));


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
    Book book = context.Books.First();
    Console.WriteLine(book);  
}

void FindSecond()
{
    var context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine("============= Find second =============");
    Book book = context.Books.First(b => b.Id == 1);
    Console.WriteLine(book);
}

void FindById(int id)
{
    var context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine($"============= Find by Id = {id} =============");
    Book book = context.Books.Find(1);
    Console.WriteLine(book);
}

void Count()
{
    var context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine($"============= Count =============");
    int rows = context.Books.Count();
    Console.WriteLine($"Total books: {rows}");
}

void Update()
{
    var context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine($"============= Update =============");
    Book bookParam = new Book { Id = 1, Description = "Some Other description from Update." };
    Book book = context.Books.Find(bookParam.Id);
    Console.WriteLine("Before Update: " + book);
    book.Description = bookParam.Description;
    context.Books.Update(book);

    context.SaveChanges();
    Console.WriteLine("After Update: " + book);
}

void Update2(Book bookParam)
{
    AppDbContext context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine($"============= Update 2 (book param) =============");
    
    context.Books.Update(bookParam);

    context.SaveChanges();
    bookParam = context.Books.Find(2);
    Console.WriteLine("After Update: " + bookParam);
}

void UpdateMulti()
{
    AppDbContext context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine($"============= Update 3 (multiple)  =============");
    Book book3 = new Book { Id = 2, Isbn = "11113", Title = "The Ender's Game- Update", ReleaseYear = 1854, Description = "asdasd" };
    Book book4 = new Book { Id = 3, Isbn = "11114", Title = "Matrix - Update", ReleaseYear = 1853, Description = "asdasd" };
    List<Book> books = new List<Book>() { book3, book4 };
    context.Books.UpdateRange(books);

    context.SaveChanges();
    Book book2 = context.Books.Find(2);
    Console.WriteLine("After Update: " + book2);
    Book book5 = context.Books.Find(3);
    Console.WriteLine("After Update: " + book5);

}

void Remove()
{
    AppDbContext context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine($"============= Delete  =============");
    Book book = context.Books.Find(3);
    if (book != null)
    {
        Console.WriteLine("Book doesn't exist");
        return;
    }
    context.Books.Remove(book);
    long before = context.Books.Count();
    context.SaveChanges();
    long after = context.Books.Count();
    Console.WriteLine(after == before - 1? "Book deleted" : "No books deleted");
}

void RemoveRange()
{
    Console.WriteLine($"============= Delete Range (2,3)  =============");
    AppDbContext context = new AppDbContextFactory().CreateDbContext(null);
    Book book3 = context.Books.Find(2);
    Book book4 = context.Books.Find(3);
    List<Book> books = new List<Book>() { book3, book4 };
    context.Books.RemoveRange(books);
    long before = context.Books.Count();
    context.SaveChanges(); 
    long after = context.Books.Count();
    Console.WriteLine(before > after ? "Books deleted " + (before - after) + " books deleted" : "No books deleted");
}

void FindByTitle(string title)
{
    AppDbContext context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine($"============= Find by title  =============");
    List<Book> books = context.Books
        .Where(book => book.Title.ToLower().Equals(title.ToLower()))
        .ToList();
    Book book = context.Books
        .Where(book => book.Title.ToLower().Equals(title.ToLower()))
        .First();
    Console.WriteLine("Books: "+ string.Join(" ,", books));
    Console.WriteLine("Single book: " + book);


}

void GetAll()
{
    var context = new AppDbContextFactory().CreateDbContext(null);
    Console.WriteLine($"============= Count =============");
    //List<Books> all = context.Books.SelectMany(b => b.Id == 3 && b.Id == 2);
}