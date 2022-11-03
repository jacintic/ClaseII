

////////////////////////////////
//////// BOOK REPO /////////////
////////////////////////////////

Console.WriteLine("=====================");
Console.WriteLine("===== Book Repo =====");
Console.WriteLine("=====================");


// 1. Crear objeto AppDbContext
AppDbContext context = new AppDbContextFactory().CreateDbContext(null);

// 2. Crear objetos Repo
IAuthorRepository authorRepoII = new AuthorDbRepository(context);
IBookRepository bookRepoII = new BookDbRepository(context);
IAddressRepository addressRepositoryII = new AddressDbRepository(context);
ICategoryRepository categoryRepoII = new CategoryDbRepository(context);

// 3. Crear Objetos Model: Asociar - Desasociar

// Address
var address21 = new Address { Street = "Calle 1", City = "Ciudad 1" };
var address22 = new Address { Street = "Calle 2", City = "Ciudad 2" };

// Category
var cat1 = new Category { Name = "cat1", MinAge = 16 };
var cat2 = new Category { Name = "cat2", MinAge = 18 };
var cat3 = new Category { Name = "cat3", MinAge = 9 };

// Author
var aut1 = new Author { FullName = "Manolin Perez", Email = "a@b.com", Salary = (decimal)3500.50, BirthDate = new DateTime(1975, 08, 15) };
var aut2 = new Author { FullName = "Francisco Garcia", Email = "c@d.com", Salary = (decimal)1500.50, BirthDate = DateTime.Now };
var aut3 = new Author { FullName = "Pedro Megia", Email = "p@m.com", Salary = (decimal)2000.50, BirthDate = DateTime.Now };

// Book
var book1 = new Book { Title = "T1", Description = "b1", Isbn = "1", ReleaseYear = 2001 };
var book2 = new Book { Title = "T2", Description = "b2", Isbn = "2", ReleaseYear = 2011 };
var book3 = new Book { Title = "T3", Description = "b3", Isbn = "3", ReleaseYear = 1995 };
var book4 = new Book { Title = "T4", Description = "b4", Isbn = "4", ReleaseYear = 2010 };


//4. Probar operaciones CRUD contra BBDD

// asociaciones
aut1.Address = address21;
aut2.Address = address22;
aut3.Address = address21;

book1.Author = aut1;
book2.Author = aut2;
book3.Author = aut3;
book4.Author = aut3;

book1.Categories = new List<Category> { cat1, cat2 };
book2.Categories = new List<Category> { cat2, cat3 };
book3.Categories = new List<Category> { cat1, cat3 };
book4.Categories = new List<Category> { cat2, cat3 };


// guardar
//authorRepoII.Create();
/*
addressRepositoryII.Create(address21);
addressRepositoryII.Create(address22);

categoryRepoII.Create(cat1);
categoryRepoII.Create(cat2);
categoryRepoII.Create(cat3);

authorRepoII.Create(aut1);
authorRepoII.Create(aut2);
authorRepoII.Create(aut3);

bookRepoII.Create(book1);
bookRepoII.Create(book2);
bookRepoII.Create(book3);
bookRepoII.Create(book4);
*/
/*
// actualizar // nota, toma la Id como referencia
var book5 = new Book {Id = 1, Title = "T1 Update", Description = "b1 update", Isbn = "1 update", ReleaseYear = 2021, AuthorId = 1 };
bookRepoII.Update(book5);

// desasociar/ actualizar relaccion autor a book
book5.AuthorId = null;
bookRepoII.Update(book5);
*/

// desasociar/ actualizar relaccion book a categories (Many To Many)
//Category cat5 = new Category { Name = "cat5", MinAge = 7 };
var book1FromDbWithAsscoiations = bookRepoII.FindByIdWithAssociations(1);
//book1FromDbWithAsscoiations.Categories.Add(cat5);
//book1FromDbWithAsscoiations.Categories.RemoveAt(0);
//bookRepoII.Update(book1FromDbWithAsscoiations);

// // adding an existing category
Category cat1FromDb = categoryRepoII.FindById(1);
book1FromDbWithAsscoiations.Categories.Add(cat1FromDb);
bookRepoII.Update(book1FromDbWithAsscoiations);

// busquedas

// borrar


void GarbageCan()
{
    Console.WriteLine("========== One To One ==========");

    // Repositories
    AppDbContext dbContext = new AppDbContextFactory().CreateDbContext(null);
    IAuthorRepository authorRepo = new AuthorDbRepository(dbContext);


    Address address1 = new Address { Street = "Fake Street 123", City = "Barcelona" };
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
    foreach (Book book in auth1.Books)
        Console.WriteLine(book.Title);

    // NO FUNCA por que no hace un Eager the auth1.Books


    Console.WriteLine("Printing books from Author with Id = 3");
    var booksFromAuth1 = dbContext.Books.Where(b => b.AuthorId == auth1.Id).ToList();
    Console.WriteLine(String.Join("\n", booksFromAuth1));



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

    dbContext.Categories.AddRange(category1, category2, category3, category4);

    dbContext.Books.AddRange(book4, book5, book6, book7, book8);

    dbContext.SaveChanges();

    // recuperar objetos de la DB

    var bookFromDb = dbContext.Books.Find(4);
    var category1FromDb = dbContext.Categories.Find(1);

    // find book 4 include categories
    var bookFromDb2 = dbContext.Books.Include(b => b.Categories).Where(b => b.Id == 4).FirstOrDefault();
    Console.WriteLine(bookFromDb2);
    Console.WriteLine(String.Join(", ", bookFromDb2.Categories));
    foreach (var category in bookFromDb2.Categories)
        Console.WriteLine("Category name: " + category.Name);

}