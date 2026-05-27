using BookSoft.Domain.Entities;
using BookSoft.Domain.Enums;
using BookSoft.Infrastructure.Data;
using BookSoft.UseCases.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.Repositories;

public class AppointmentRepository : IAppointmentRepo
{
    private readonly BookSoftDbContext _db;

    public AppointmentRepository(BookSoftDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<Appointment>> GetAllAsync()
    {
        return await _db.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Practitioner)
            .ToListAsync();
    }

    public async Task<Appointment?> GetByIdAsync(Guid id)
    {
        return await _db.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Practitioner)
            .FirstOrDefaultAsync(a => a.ID == id);
    }

    public async Task<IReadOnlyList<Appointment>> GetByPatientIdAsync(Guid patientId)
    {
        return await _db.Appointments
            .Where(a => a.PatientId == patientId)
            .Include(a => a.Practitioner)
            .OrderByDescending(a => a.AppointmentStartTime)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Appointment>> GetByPractitionerIdAsync(Guid practitionerId)
    {
        return await _db.Appointments
            .Where(a => a.PractitionerId == practitionerId)
            .Include(a => a.Patient)
            .OrderByDescending(a => a.AppointmentStartTime)
            .ToListAsync();
    }

    // overlap tjek - A overlapper B hvis A.start < B.slut og A.slut > B.start
    // springer aflyste aftaler over
    public async Task<bool> HasClashAsync(Guid practitionerId, DateTime start, DateTime end)
    {
        return await _db.Appointments
            .AnyAsync(a =>
                a.PractitionerId == practitionerId
                && a.AppointmentStatus != AppointmentStatusEnum.Cancelled
                && a.AppointmentStartTime < end
                && a.AppointmentEndTime > start);
    }

    public async Task AddAsync(Appointment appointment)
    {
        await _db.Appointments.AddAsync(appointment);
    }

    public void Update(Appointment appointment)
    {
        _db.Appointments.Update(appointment);
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}
