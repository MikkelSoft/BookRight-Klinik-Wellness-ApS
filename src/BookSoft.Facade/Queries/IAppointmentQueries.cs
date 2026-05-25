using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Facade.DTOs;

namespace BookSoft.Facade.Queries
{
    public interface IAppointmentQueries
    {
        Task<AppointmentDto> GetAsync(Guid id);
        Task<IReadOnlyList<AppointmentDto>> GetAllAsync();
        Task<IReadOnlyList<AppointmentDto>> GetByPatientIdAsync(Guid patientId);
        Task<IReadOnlyList<AppointmentDto>> GetByPractitionerIdAsync(Guid practitionerId);
    }
}
