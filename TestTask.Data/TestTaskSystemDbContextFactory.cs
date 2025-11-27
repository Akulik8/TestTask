using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TestTask.Data
{
    public class TestTaskSystemDbContextFactory
        : IDesignTimeDbContextFactory<TestTaskSystemDbContext>
    {
        public TestTaskSystemDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "TestTask.API");
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .AddEnvironmentVariables(); 

            var configuration = configBuilder.Build();

            var connectionString =
                configuration.GetConnectionString("DefaultConnection")
                ?? "Host=localhost; Port = 5432; Database = car_db; Username = postgres; Password = 2616";

            var optionsBuilder = new DbContextOptionsBuilder<TestTaskSystemDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new TestTaskSystemDbContext(optionsBuilder.Options);
        }
    }
}
