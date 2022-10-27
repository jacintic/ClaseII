﻿
namespace DotNet1.Db;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    // add a DbSet for every model we have
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}