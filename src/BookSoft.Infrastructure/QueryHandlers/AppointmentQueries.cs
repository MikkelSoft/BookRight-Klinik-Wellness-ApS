using BookSoft.Facade.DTOs;
using Microsoft.EntityFrameworkCore;
using BookSoft.Facade.Queries;
using BookSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace BookSoft.Infrastructure.QueryHandlers
{
    public class AppointmentQueriesImp : IAppointmentQueries
    {
        private readonly BookSoftDbContext _db;

        public AppointmentQueriesImp(BookSoftDbContext db)
        {
            _db = db;
        }

        public async Task<AppointmentDto?> GetByIdAsync(Guid id)
        {
            return await _db.Appointments
                .AsNoTracking()
                .Where(a => a.ID == id)
                .Select(a => new AppointmentDto
                (
                    a.ID,
                    a.PatientId,
                    a.PractitionerId,
                    a.ClinicId,
                    a.AppointmentType.ToString(),
                    a.AppointmentStartTime,
                    a.AppointmentEndTime,
                    a.Patient.FullName.FirstName + a.Patient.FullName.MiddleNames + a.Patient.FullName.LastName,
                    a.Practitioner.FullName.FirstName + a.Practitioner.FullName.MiddleNames + a.Practitioner.FullName.LastName,
                    a.Clinic.ClinicName
                ))
                .FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<AppointmentDto>> GetAllAsync()
        {
            return await _db.Appointments
                .AsNoTracking()
                .Select(a => new AppointmentDto
                (
                    a.ID,
                    a.PatientId,
                    a.PractitionerId,
                    a.ClinicId,
                    a.AppointmentType.ToString(),
                    a.AppointmentStartTime,
                    a.AppointmentEndTime,
                    a.Patient.FullName.FirstName + a.Patient.FullName.MiddleNames + a.Patient.FullName.LastName,
                    a.Practitioner.FullName.FirstName + a.Practitioner.FullName.MiddleNames + a.Practitioner.FullName.LastName,
                    a.Clinic.ClinicName
                ))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<AppointmentDto>> GetByPatientIdAsync(Guid patientId)
        {
            return await _db.Appointments
                .AsNoTracking()
                .Where(a => a.PatientId == patientId)
                .Select(a => new AppointmentDto
                (
                    a.ID,
                    a.PatientId,
                    a.PractitionerId,
                    a.ClinicId,
                    a.AppointmentType.ToString(),
                    a.AppointmentStartTime,
                    a.AppointmentEndTime,
                    a.Patient.FullName.FirstName + a.Patient.FullName.MiddleNames + a.Patient.FullName.LastName,
                    a.Practitioner.FullName.FirstName + a.Practitioner.FullName.MiddleNames + a.Practitioner.FullName.LastName,
                    a.Clinic.ClinicName
                ))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<AppointmentDto>> GetByPractitionerIdAsync(Guid practitionerId)
        {
            return await _db.Appointments
                .AsNoTracking()
                .Where(a => a.PractitionerId == practitionerId)
                .Select(a => new AppointmentDto
                (
                    a.ID,
                    a.PatientId,
                    a.PractitionerId,
                    a.ClinicId,
                    a.AppointmentType.ToString(),
                    a.AppointmentStartTime,
                    a.AppointmentEndTime,
                    a.Patient.FullName.FirstName + a.Patient.FullName.MiddleNames + a.Patient.FullName.LastName,
                    a.Practitioner.FullName.FirstName + a.Practitioner.FullName.MiddleNames + a.Practitioner.FullName.LastName,
                    a.Clinic.ClinicName
                ))
                .ToListAsync();
        }
    }
}
