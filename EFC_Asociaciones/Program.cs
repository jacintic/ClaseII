Console.WriteLine("========== One To One ==========");

// Repositories
AppDbContext dbContext = new AppDbContextFactory().CreateDbContext(null);
IAuthorRepository authorRepo = new AuthorDbRepository(dbContext);


Address address1 = new Address { Street = "Fake Street 123", City = "Barcelona"};
Author auth1 = new Author();
auth1.Email = "auth1@example.com";
auth1.FullName = "John 1 from Address association program";
auth1.Salary = 5000;
auth1.BirthDate = new DateTime(1977, 05, 12);
auth1.Address = address1;
Console.WriteLine(authorRepo.Create(auth1));

Console.WriteLine("========== One To Many ==========");
Book book1 = new Book
{
    Title = "book1",
    Description = "adsasd",
    Isbn = "asdasd",
    ReleaseYear = 1994,
    Author = auth1,
};
Book book2 = new Book
{
    Title = "book2",
    Description = "adsasd",
    Isbn = "asdasd",
    ReleaseYear = 1994,
    Author = auth1,
};
Book book3 = new Book
{
    Title = "book3",
    Description = "adsasd",
    Isbn = "asdasd",
    ReleaseYear = 1994,
    Author = auth1,
};

dbContext.Books.AddRange(book1, book2, book3);
dbContext.SaveChanges();

Console.WriteLine("========== Many To Many ==========");



