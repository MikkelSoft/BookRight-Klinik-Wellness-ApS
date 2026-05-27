using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Facade.DTOs;

namespace BookSoft.Facade.Queries
{
    // BookSoft.Facade/Queries/IAppointmentQueries.cs
    public interface IAppointmentQueries
    {
        Task<IReadOnlyList<AppointmentDto>> GetAllAsync();
        Task<AppointmentDto?> GetByIdAsync(Guid Id);  // add the ?
        Task<IReadOnlyList<AppointmentDto>> GetByPatientIdAsync(Guid patientId);
        Task<IReadOnlyList<AppointmentDto>> GetByPractitionerIdAsync(Guid practitionerId);
    }
}
    