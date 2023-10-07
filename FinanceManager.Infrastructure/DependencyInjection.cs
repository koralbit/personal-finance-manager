using FinanceManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<ApplicationDbContext>(options =>
                          options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                                           b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        //services.AddDbContext<ApplicationDbContext>(options =>
        //           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        //                          b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        return services;
    }
}
