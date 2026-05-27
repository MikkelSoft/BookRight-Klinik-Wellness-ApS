using System;
using System.Collections.Generic;
using System.Text;
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

    // GET all
    public async Task<IReadOnlyList<Appointment>> GetAllAsync()
    {
        return await _db.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Practitioner)
            .ToListAsync();
    }

    // GET by Id
    public async Task<Appointment?> GetByIdAsync(Guid id)
    {
        return await _db.Appointments
            .Include(a => a.Patient)
            .Include(a => a.Practitioner)
            .FirstOrDefaultAsync(a => a.ID == id);
    }

    // GET by patient
    public async Task<IReadOnlyList<Appointment>> GetByPatientIdAsync(Guid patientId)
    {
        return await _db.Appointments
            .Where(a => a.PatientId == patientId)
            .Include(a => a.Practitioner)
            .OrderByDescending(a => a.AppointmentStartTime)
            .ToListAsync();
    }

    // GET by practitioner
    public async Task<IReadOnlyList<Appointment>> GetByPractitionerIdAsync(Guid practitionerId)
    {
        return await _db.Appointments
            .Where(a => a.PractitionerId == practitionerId)
            .Include(a => a.Patient)
            .OrderByDescending(a => a.AppointmentStartTime)
            .ToListAsync();
    }
    /* kommenteret ud da det ikke anvendes og der er ikke tilsvarende oprettet i IAppointmentRepo i usecase
    // GET by date range
    public async Task<List<Appointment>> GetByDateRangeAsync(DateTime from, DateTime to, CancellationToken ct = default)
    {
        return await _db.Appointments
            .Where(a => a.AppointmentStartTime >= from && a.AppointmentStartTime <= to)
            .Include(a => a.Patient)
            .Include(a => a.Practitioner)
            .OrderBy(a => a.AppointmentStartTime)
            .ToListAsync(ct);
    }

    // GET by status
    public async Task<List<Appointment>> GetByStatusAsync(AppointmentStatusEnum status, CancellationToken ct = default)
    {
        return await _db.Appointments
            .Where(a => a.AppointmentStatus == status)
            .Include(a => a.Patient)
            .Include(a => a.Practitioner)
            .ToListAsync(ct);
    }

    // GET by type
    public async Task<List<Appointment>> GetByTypeAsync(AppointmentTypeEnum type, CancellationToken ct = default)
    {
        return await _db.Appointments
            .Where(a => a.AppointmentType == type)
            .Include(a => a.Patient)
            .Include(a => a.Practitioner)
            .ToListAsync(ct);
    }

    // CHECK for clashing appointments for a practitioner
    public async Task<bool> HasClashAsync(Guid practitionerId, DateTime start, DateTime end, CancellationToken ct = default)
    {
        return await _db.Appointments
            .AnyAsync(a => a.PractitionerId == practitionerId
                        && a.AppointmentStartTime < end
                        && a.AppointmentEndTime > start, ct);
    }*/

    // CREATE
    public async Task AddAsync(Appointment appointment)
    {
        await _db.Appointments.AddAsync(appointment);
    }

    // UPDATE //behøver ikke update i EF
    public void Update(Appointment appointment)
    {
        _db.Appointments.Update(appointment);
    }

    // SAVE
    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}
