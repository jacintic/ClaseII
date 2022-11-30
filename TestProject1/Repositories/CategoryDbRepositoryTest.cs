namespace TestProject1.Repositories;

public class CategoryDbRepositoryTest
{
    [Fact]
    public void FindAllTest()
    {
        AppDbContext context = CreateContext();
        
        ICategoryRepository categoryRepo = new CategoryDbRepository(context);
        List<Category> categories = categoryRepo.FindAll(); 
        
        Assert.NotEmpty(categories);
        Assert.Equal(4, categories.Count());
        context.Dispose();
    }

    [Fact]
    public void FindByIdTest()
    {
        AppDbContext context = CreateContext();

        ICategoryRepository categoryRepo = new CategoryDbRepository(context);
        Category category = categoryRepo.FindById(1);

        Assert.NotNull(category);
        Assert.Equal(1, category.Id);
        Assert.Equal("cat1", category.Name);
        context.Dispose();
    }

    [Fact]
    public void FindByMinageTest()
    {
        AppDbContext context = CreateContext();

        ICategoryRepository categoryRepo = new CategoryDbRepository(context);
        List<Category> category = categoryRepo.FindByMinAge(30);

        Assert.NotNull(category);;
        Assert.Equal(2, category.Count);
        context.Dispose();
    }

    [Fact]
    public void FindByIdInTest()
    {
        AppDbContext context = CreateContext();

        ICategoryRepository categoryRepo = new CategoryDbRepository(context);
        List<Category> categories = categoryRepo.FindAllByIdIn(new List<int> { 1, 3 });

        Assert.NotEmpty(categories);
        Assert.NotNull(categories);
        Assert.Equal(2, categories.Count);
        context.Dispose();
    }

    [Fact]
    public void CreateTest()
    {
        AppDbContext context = CreateContext();

        ICategoryRepository categoryRepo = new CategoryDbRepository(context);
        Category cat1 = new() { Name = "cat5", MinAge = 40};

        Assert.Equal(context.Categories.Count(), 4);
        Category cat1Db = categoryRepo.Create(cat1);

        Assert.Equal(context.Categories.Count(), 5);
        Assert.Equal(cat1Db.Id, 5);
        context.Dispose();
    }


    [Fact]
    public void UpdateTest()
    {
        AppDbContext context = CreateContext();

        ICategoryRepository categoryRepo = new CategoryDbRepository(context);

        Category category1 = context.Categories.Find(1);
        category1.MinAge = 55;
        categoryRepo.Update(category1);
        
        Assert.Equal(context.Categories.Find(1).MinAge, 55);

        context.Dispose();
    }




    private AppDbContext CreateContext()
    {
        // create MySQL DB setting
        string url = "server=localhost;port=3306;user=root;password=admin;database=cursonet";
        var options = new DbContextOptionsBuilder<AppDbContext>()
                        .UseMySql(url, ServerVersion.AutoDetect(url))
                        .Options;
        AppDbContext context = new AppDbContext(options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        Category cat1 = new () { Name = "cat1", MinAge = 20 };
        Category cat2 = new () { Name = "cat2", MinAge = 25 };
        Category cat3 = new() { Name = "cat2", MinAge = 30 };
        Category cat4 = new() { Name = "cat2", MinAge = 35 };

        context.AddRange(new List<Category> { cat1, cat2, cat3, cat4 });
        context.SaveChanges();

        return context;
    }
}