using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace APP_DD.Entity_Framework
{
    public static class DB
    {
        private static readonly IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
        private static readonly DbContextOptions<DatabaseContext> options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(builder.Build().GetConnectionString("DefaultConnection")).Options;
        public static DatabaseContext connector = new(options);

    }
}
