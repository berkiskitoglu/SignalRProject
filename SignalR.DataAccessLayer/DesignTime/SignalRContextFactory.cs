using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SignalR.DataAccessLayer.Concrete;


namespace SignalR.DataAccessLayer.DesignTime
{
    public class SignalRContextFactory : IDesignTimeDbContextFactory<SignalRContext>
    {
        public SignalRContext CreateDbContext(string[] args)
        {
           
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\SignalRApi");

            if (!File.Exists(Path.Combine(basePath, "appsettings.json")))
            {
                throw new FileNotFoundException("appsettings.json bulunamadı!", basePath);
            }

            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("DefaultConnection connection string boş veya bulunamadı!");
            }

            var optionsBuilder = new DbContextOptionsBuilder<SignalRContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SignalRContext(optionsBuilder.Options);
        }
    }
}
