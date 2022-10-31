Console.WriteLine("========== One To One ==========");

// Repositories
AppDbContext dbContext = new AppDbContextFactory().CreateDbContext(null);
IAuthorRepository authorRepo = new AuthorDbRepository(dbContext);


Address address1 = new Address { Street = "Fake Street 123", City = "Barcelona"};
Author auth1 = new Author();
auth1.Email = "auth1@example.com";
auth1.FullName = "Auth 1 from Address association program";
auth1.Salary = 5000;
auth1.BirthDate = new DateTime(1977, 05, 12);
auth1.Address = address1;
var authorCreated = authorRepo.Create(auth1);

