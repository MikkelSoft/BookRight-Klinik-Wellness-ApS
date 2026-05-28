using BookSoft.Domain.Rabatter;
using BookSoft.Domain.Rabatter.Strategier;
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
        // database - connection string kommer fra appsettings.json
        services.AddDbContext<BookSoftDbContext>(opts =>
            opts.UseSqlServer(config.GetConnectionString("Default")));

        // repositories
        services.AddScoped<IAppointmentRepo, AppointmentRepository>();
        services.AddScoped<IPatientRepo, PatientRepository>();
        services.AddScoped<IPractitionerRepo, PractitionerRepository>();
        services.AddScoped<ITransactionRepo, TransactionRepository>();
        services.AddScoped<IClinicRepo, ClinicRepository>();
        services.AddScoped<ICampaignRepo, CampaignRepository>();

        // query handlers - read only, går direkte fra db til dto
        services.AddScoped<IAppointmentQueries, AppointmentQueriesImp>();
        services.AddScoped<IPatientQueries, PatientQueriesImp>();
        services.AddScoped<IPractitionerQueries, PractitionerQueriesImp>();
        services.AddScoped<IClinicQueries, ClinicQueriesImp>();
        services.AddScoped<ITransactionQueries, TransactionQueriesImp>();
        services.AddScoped<ICampaignQueries, CampaignQueriesImp>();

        // rabat strategier - alle registreres som IRabatBeregner
        // RabatService får dem injected som IEnumerable og kører dem i parallel
        services.AddScoped<IRabatBeregner, BronzeLoyalitetRabat>();
        services.AddScoped<IRabatBeregner, SolvLoyalitetRabat>();
        services.AddScoped<IRabatBeregner, GuldLoyalitetRabat>();
        services.AddScoped<IRabatBeregner, FoedselsdagsRabat>();
        services.AddScoped<IRabatBeregner, KampagneRabat>();
        services.AddScoped<RabatService>();

        return services;
    }
}
