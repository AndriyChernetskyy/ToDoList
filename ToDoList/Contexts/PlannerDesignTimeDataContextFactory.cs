using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using System.IO;

namespace ToDoList.Contexts
{
    public class PlannerDesignTimeDataContextFactory : IDesignTimeDbContextFactory<PlannerContext>
    {
        private const string ConnectionParameterName = "DefaultConnection";

        public PlannerContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PlannerContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString(ConnectionParameterName));
            return new PlannerContext(optionsBuilder.Options);
        }
    }
}
