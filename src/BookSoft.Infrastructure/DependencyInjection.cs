using BookSoft.Infrastructure.Data;
using BookSoft.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookSoft.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<BookSoftDbContext>(opts =>
            opts.UseSqlServer(config.GetConnectionString("Default")));

        services.AddScoped<PatientRepository>();
        services.AddScoped<PractitionerRepository>();
        services.AddScoped<AppointmentRepository>();
        services.AddScoped<TransactionRepository>();
        services.AddScoped<ClinicRepository>();

        return services;
    }
}