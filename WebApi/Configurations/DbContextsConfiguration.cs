using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Configurations
{
    public static class DbContextsConfiguration
    {
        public static void RegisterDBContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LocalDatabase"));
            });

        }
    }
}
