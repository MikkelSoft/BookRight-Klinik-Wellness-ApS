using BookSoft.Facade.DTOs;
using Microsoft.EntityFrameworkCore;
using BookSoft.Facade.Queries;
using BookSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
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

        private static AppointmentDto MapToDto(BookSoft.Domain.Entities.Appointment a) => new AppointmentDto(
            a.ID,
            a.PatientId,
            a.PractitionerId,
            a.ClinicId,
            a.AppointmentType.ToString(),
            a.AppointmentStartTime,
            a.AppointmentEndTime,
            string.Join(" ", a.Patient!.FullName.FirstName, a.Patient.FullName.MiddleNames, a.Patient.FullName.LastName).Trim(),
            string.Join(" ", a.Practitioner!.FullName.FirstName, a.Practitioner.FullName.MiddleNames, a.Practitioner.FullName.LastName).Trim(),
            a.Clinic!.ClinicName,
            a.Pris,
            a.AnvendtRabatType
        );

        public async Task<AppointmentDto?> GetByIdAsync(Guid id)
        {
            var a = await _db.Appointments
                .AsNoTracking()
                .Include(a => a.Patient)
                .Include(a => a.Practitioner)
                .Include(a => a.Clinic)
                .Where(a => a.ID == id)
                .FirstOrDefaultAsync();

            if (a is null) return null;

            return MapToDto(a);
        }

        public async Task<IReadOnlyList<AppointmentDto>> GetAllAsync()
        {
            var appointments = await _db.Appointments
                .AsNoTracking()
                .Include(a => a.Patient)
                .Include(a => a.Practitioner)
                .Include(a => a.Clinic)
                .ToListAsync();

            return appointments.Select(MapToDto).ToList();
        }

        public async Task<IReadOnlyList<AppointmentDto>> GetByPatientIdAsync(Guid patientId)
        {
            var appointments = await _db.Appointments
                .AsNoTracking()
                .Where(a => a.PatientId == patientId)
                .Include(a => a.Patient)
                .Include(a => a.Practitioner)
                .Include(a => a.Clinic)
                .OrderByDescending(a => a.AppointmentStartTime)
                .ToListAsync();

            return appointments.Select(MapToDto).ToList();
        }

        public async Task<IReadOnlyList<AppointmentDto>> GetByPractitionerIdAsync(Guid practitionerId)
        {
            var appointments = await _db.Appointments
                .AsNoTracking()
                .Where(a => a.PractitionerId == practitionerId)
                .Include(a => a.Patient)
                .Include(a => a.Practitioner)
                .Include(a => a.Clinic)
                .OrderByDescending(a => a.AppointmentStartTime)
                .ToListAsync();

            return appointments.Select(MapToDto).ToList();
        }
    }
}