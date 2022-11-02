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

Console.WriteLine("========== Many To One ==========");
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

Book book1FromDb = dbContext.Books.Find(1);
// Console.WriteLine(book1FromDb.Author.FullName); // no lo trae, error
// alternativa
// usar ID para traer objeto
Console.WriteLine(dbContext.Authors.Find(book1FromDb.AuthorId));

Console.WriteLine("========== Many To One ==========");
// Author -> Books (One To Many)
auth1 = dbContext.Authors.Find(1);
/*foreach (Book book in auth1.Books)
    Console.WriteLine(book.Title);

*/  // NO FUNCA por que no hace un Eager the auth1.Books

/*
Console.WriteLine("Printing books from Author with Id = 3");
var booksFromAuth1 = dbContext.Books.Where(b => b.AuthorId == auth1.Id).ToList();
Console.WriteLine(String.Join("\n", booksFromAuth1));

*/

Console.WriteLine("========== Many To Many ==========");

Book book4 = new Book
{
    Title = "book4",
    Description = "adsasd",
    Isbn = "asdasd",
    ReleaseYear = 1994,
    Author = auth1,
    
};
Book book5 = new Book
{
    Title = "book5",
    Description = "adsasd",
    Isbn = "asdasd",
    ReleaseYear = 1994,
    Author = auth1,
    
};
Book book6 = new Book
{
    Title = "book6",
    Description = "adsasd",
    Isbn = "asdasd",
    ReleaseYear = 1994,
    Author = auth1,
    
};
Book book7 = new Book
{
    Title = "book7",
    Description = "adsasd",
    Isbn = "asdasd",
    ReleaseYear = 1994,
    Author = auth1,
    
};
Book book8 = new Book
{
    Title = "book8",
    Description = "adsasd",
    Isbn = "asdasd",
    ReleaseYear = 1994,
    Author = auth1,
    
};

var category1 = new Category { Name = "c1", MinAge = 18 };
var category2 = new Category { Name = "c2", MinAge = 16 };
var category3 = new Category { Name = "c3", MinAge = 9 };
var category4 = new Category { Name = "c4", MinAge = 3 };

book4.Categories = new List<Category> { category1, category2 };
book5.Categories = new List<Category> { category2, category3 };
book6.Categories = new List<Category> { category2, category4 };
book7.Categories = new List<Category> { category2, category3 };
book8.Categories = new List<Category> { category4 };

dbContext.Categories.AddRange(category1,category2,category3,category4);

dbContext.Books.AddRange(book4, book5, book6, book7, book8);

dbContext.SaveChanges();

// recuperar objetos de la DB

var bookFromDb = dbContext.Books.Find(4);
var category1FromDb = dbContext.Categories.Find(1);

// find book 4 include categories
var bookFromDb2 = dbContext.Books.Include(b => b.Categories).Where(b => b.Id == 4).FirstOrDefault();
Console.WriteLine(bookFromDb2);
Console.WriteLine(String.Join(", ",bookFromDb2.Categories));

