using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Essence.Test.RepositoryCore
{
    public class EssenceTesteContextFactory : IDesignTimeDbContextFactory<EssenceTesteContext>
    {        
        public EssenceTesteContext CreateDbContext(string[] args)
        {
            string connectionString = GetConnectionString();

            var builder = new DbContextOptionsBuilder<EssenceTesteContext>();

            builder.UseSqlServer(connectionString);
            return new EssenceTesteContext(builder.Options);
        }

        public static string GetConnectionString()
        {
            var config = new ConfigurationBuilder();
            config.SetBasePath(Directory.GetCurrentDirectory());
            config.AddJsonFile("appsettings.json");
            var configuration = config.Build();

            var connectionString = configuration.GetConnectionString("EssenceTesteEntities");
            return connectionString;
        }

        public static void Register(object iServiceCollectionservices, string connectionString)
        {
            IServiceCollection services = (IServiceCollection)iServiceCollectionservices;
            services.AddDbContext<EssenceTesteContext>((serviceProvider, options) =>
                options.UseSqlServer(connectionString)
                .UseInternalServiceProvider(serviceProvider));
        }
    }
}
