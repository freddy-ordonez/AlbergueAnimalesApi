using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistence;

namespace AlbergueAnimalesRescatadosApi.ContexFactory
{
    public class RepositoryContexFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlServer(config.GetConnectionString("sqlConnection"),
                    b => b.MigrationsAssembly("AlbergueAnimalesRescatadosApi"));

            return new RepositoryContext(builder.Options);
        }
    }
}
