using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Facade.DTOs;

namespace BookSoft.Facade.Queries
{
    public interface IAppointmentQueries
    {
        Task<IReadOnlyList<AppointmentDto>> GetAllAsync();
        Task<AppointmentDto> GetByIdAsync(Guid Id);
        Task<IReadOnlyList<AppointmentDto>> GetByPatientIdAsync(Guid patientId); //behøver dette at være en list?
        Task<IReadOnlyList<AppointmentDto>> GetByPractitionerIdAsync(Guid practitionerId);
    }
}
