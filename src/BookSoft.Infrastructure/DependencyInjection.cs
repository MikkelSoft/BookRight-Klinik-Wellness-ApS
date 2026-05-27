using BookSoft.Facade.Queries;
using BookSoft.Infrastructure.Data;
using BookSoft.Infrastructure.QueryHandlers;
using BookSoft.Infrastructure.Repositories;
using BookSoft.UseCases.IRepositories;
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
        // Database
        services.AddDbContext<BookSoftDbContext>(opts =>
            opts.UseSqlServer(config.GetConnectionString("Default")));

        // Repositories — concrete classes
        services.AddScoped<PatientRepository>();
        services.AddScoped<PractitionerRepository>();
        services.AddScoped<AppointmentRepository>();
        services.AddScoped<TransactionRepository>();
        services.AddScoped<ClinicRepository>();

        // Repositories > interface > implementation for use cases
        services.AddScoped<IAppointmentRepo, AppointmentRepository>();
        services.AddScoped<IPatientRepo, PatientRepository>();
        services.AddScoped<IPractitionerRepo, PractitionerRepository>();

        // Query handlers
        services.AddScoped<IAppointmentQueries, AppointmentQueriesImp>();

        return services;
    }
}