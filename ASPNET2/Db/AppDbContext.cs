
namespace ASPNET2.Db;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    // add a DbSet for every model we have
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

/*
    // Setting columns on a global level
    protected override void ConfigureConventions(ModelConfigurationBuilder confBuilder)
    {
        confBuilder.Properties<string>().HaveMaxLength(100);
    }
*/
}
