using BookSoft.Facade.DTOs.BookSoft.Facade.DTOs;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.Appointments;
using BookSoft.UseCases.PatientUseCases;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection;

public static class UseCasesServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IAddPatientUseCase, AddPatientUseCase>();

        services.AddScoped<ICreateNewAppointmentUseCase, CreateNewAppointmentUseCase>();
        services.AddScoped<ICancelAppointmentUseCase, CancelAppointmentUseCase>();
        //services.AddScoped<IFinishAppointmentUseCase, FinishAppointmentUseCase>();

        return services;
    }
}