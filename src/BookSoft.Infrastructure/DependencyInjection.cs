using BookSoft.Infrastructure.Data;
using BookSoft.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookSoft.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
        var connectionString = config.GetConnectionString("Server=localhost;Database=BookSoftDB;Trusted_Connection=True;TrustServerCertificate=True");

        services.AddScoped<PatientRepository>();
        services.AddScoped<PractitionerRepository>();
        services.AddScoped<AppointmentRepository>();
        services.AddScoped<TransactionRepository>();
        services.AddScoped<ClinicRepository>();

        return services;
    }
}