using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Entities;

namespace BookSoft.UseCases.IRepositories
{
    public interface IAppointmentRepo
    {
        Task<Appointment?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<Appointment>> GetByPatientIdAsync(Guid patientId);
        Task<IReadOnlyList<Appointment>> GetByPractitionerIdAsync(Guid practitionerId);
        Task AddAsync(Appointment appointment);
        Task SaveAsync();
    }
}
