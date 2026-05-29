using BookSoft.Facade.UseCases;
using BookSoft.UseCases.Appointments;
using BookSoft.UseCases.AppointmentUseCases;
using BookSoft.UseCases.CampaignUseCases;
using BookSoft.UseCases.ClinicUseCases;
using BookSoft.UseCases.PatientUseCases;
using BookSoft.UseCases.PractitionerUseCases;

namespace Microsoft.Extensions.DependencyInjection;

public static class UseCasesServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        // patient
        services.AddScoped<IAddPatientUseCase, AddPatientUseCase>();
        services.AddScoped<IUpdatePatientUseCase, UpdatePatientUseCase>();
        services.AddScoped<IRemovePatientUseCase, RemovePatientUseCase>();

        // behandler
        services.AddScoped<IAddPractitionerUseCase, AddPractitionerUseCase>();
        services.AddScoped<IUpdatePractitionerUseCase, UpdatePractitionerUseCase>();
        services.AddScoped<IRemovePractitionerUseCase, RemovePractitionerUseCase>();

        // klinik
        services.AddScoped<IAddClinicUseCase, AddClinicUseCase>();
        services.AddScoped<IUpdateClinicUseCase, UpdateClinicUseCase>();
        services.AddScoped<IRemoveClinicUseCase, RemoveClinicUseCase>();

        // aftaler
        services.AddScoped<ICreateNewAppointmentUseCase, CreateNewAppointmentUseCase>();
        services.AddScoped<ICancelAppointmentUseCase, CancelAppointmentUseCase>();
        services.AddScoped<IFinishAppointmentUseCase, FinishAppointmentUseCase>();

        // kampagner
        services.AddScoped<IAddCampaignUseCase, AddCampaignUseCase>();
        services.AddScoped<IRemoveCampaignUseCase, RemoveCampaignUseCase>();

        return services;
    }
}
