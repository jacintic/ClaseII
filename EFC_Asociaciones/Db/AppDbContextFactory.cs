using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Asociaciones.Db;
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        // create MySQL DB setting
        string url = "server=localhost;port=3306;user=root;password=admin;database=dotnet";
        var options = new DbContextOptionsBuilder<AppDbContext>()
                        .UseMySql(url, ServerVersion.AutoDetect(url))
                        .Options;
        return new AppDbContext(options);
    }
}
