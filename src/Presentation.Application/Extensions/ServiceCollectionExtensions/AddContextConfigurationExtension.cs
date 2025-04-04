using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FioTec.Service.Presentation.Application.Extensions.ServiceCollectionExtensions;

public static class AddContextConfigurationExtension
{
    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(
                 configuration.GetConnectionString("DefaultConnection"),
                 b => b.MigrationsAssembly("FioTec.Infrastructure.Data")
             )
         );

        return services;
    }
}
