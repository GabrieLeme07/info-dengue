using FioTec.Service.Domain.Reports.Interfaces;
using FioTec.Service.Domain.Reports.Services;
using FioTec.Service.Domain.Users.Interfaces;
using Infrastructure.Adapter.InfoDengue.Adapters;
using Infrastructure.Adapter.InfoDengue.Interfaces;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repository;

namespace FioTec.Service.Presentation.Application.Extensions.ServiceCollectionExtensions;

public static class AddServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<AppDbContext>();

        // Adapter
        services.AddHttpClient<IInfodengueAdapter, InfodengueAdapter>();

        // Service
        services.AddScoped<IReportService, ReportService>();

        // Repository
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();

        return services;
    }
}