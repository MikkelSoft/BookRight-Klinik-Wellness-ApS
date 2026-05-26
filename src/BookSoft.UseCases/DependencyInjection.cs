using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.Appointments;

namespace Microsoft.Extensions.DependencyInjection;

public static class UseCasesServiceCollectionExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICreateNewAppointmentUseCase, CreateNewAppointmentUseCase>();

        return services;
    }
}