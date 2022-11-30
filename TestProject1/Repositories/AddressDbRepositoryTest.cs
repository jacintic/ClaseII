namespace TestProject1.Repositories;

public class AddressDbRepositoryTest
{
    [Fact]
    public void FindAllTest()
    {
        AppDbContext context = CreateContext();
        
        

        Address add1 = new() { City = "Barcelona", Street = "Fake Street 123" };
        Address add2 = new() { City = "Madrid", Street = "Fake Street 234" };
        Address add3 = new() { City = "Cuenca", Street = "Fake Street 56" };
        Address add4 = new() { City = "Badajoz", Street = "Fake Street 23" };
        context.Addresses.AddRange(new List<Address> { add1, add2, add3, add4 });
        context.SaveChanges();

        IAddressRepository addressRepo = new AddressDbRepository(context);
        List<Address> addresses = addressRepo.FindAll();

        Assert.NotEmpty(addresses);
        Assert.Equal(4, addresses.Count());
        context.Dispose();
    }

    [Fact]
    public void FindByIdTest()
    {
        AppDbContext context = CreateContext();



        Address add1 = new() { City = "Barcelona", Street = "Fake Street 123" };
        context.Addresses.Add(add1);
        context.SaveChanges();

        IAddressRepository addressRepo = new AddressDbRepository(context);
        Address addressDb = addressRepo.FindById(1);

        Assert.NotNull(addressDb);
        Assert.Equal(1, addressDb.Id);
        context.Dispose();
    }


    //[Fact]
    //public void UpdateTest()
    //{
    //    AppDbContext context = CreateContext();



    //    Address add1 = new() { City = "Barcelona", Street = "Fake Street 123" };
    //    context.Addresses.Add(add1);
    //    context.SaveChanges();

    //    IAddressRepository addressRepo = new AddressDbRepository(context);
    //    Address addressDb = addressRepo.FindById(1);
    //    addressDb.City = "Honululu";
    //    Address ad =addressRepo.Update(addressDb);

    //    Assert.NotEmpty(addresses);
    //    Assert.Equal(4, addresses.Count());
    //    context.Dispose();
    //}

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

        

        
        context.SaveChanges();

        return context;
    }
}