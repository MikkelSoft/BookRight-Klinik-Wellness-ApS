using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Entities;
using BookSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.Repositories;

public class PractitionerRepository
{
    private readonly BookSoftDbContext _ctx;

    public PractitionerRepository(BookSoftDbContext ctx)
    {
        _ctx = ctx;
    }

    // GET all
    public async Task<List<Practitioner>> GetAllAsync(CancellationToken ct = default)
    {
        return await _ctx.Practitioners
            .Include(p => p.Appointments)
            .ToListAsync(ct);
    }

    // GET by Id
    public async Task<Practitioner?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _ctx.Practitioners
            .Include(p => p.Appointments)
            .FirstOrDefaultAsync(p => p.ID == id, ct);
    }

    // GET by specialty
    public async Task<List<Practitioner>> GetBySpecialtyAsync(string specialty, CancellationToken ct = default)
    {
        return await _ctx.Practitioners
            .Where(p => p.Specialty.ToLower() == specialty.ToLower())
            .Include(p => p.Appointments)
            .ToListAsync(ct);
    }

    // GET available on a given date (no appointment clashes)
    public async Task<List<Practitioner>> GetAvailableAsync(DateTime date, CancellationToken ct = default)
    {
        return await _ctx.Practitioners
            .Include(p => p.Appointments)
            .Where(p => p.Appointments.All(a => a.AppointmentStartTime.Date != date.Date))
            .ToListAsync(ct);
    }

    // CREATE
    public async Task AddAsync(Practitioner practitioner, CancellationToken ct = default)
    {
        await _ctx.Practitioners.AddAsync(practitioner, ct);
    }

    // UPDATE
    public void Update(Practitioner practitioner)
    {
        _ctx.Practitioners.Update(practitioner);
    }

    // DELETE
    public void Delete(Practitioner practitioner)
    {
        _ctx.Practitioners.Remove(practitioner);
    }

    // SAVE
    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await _ctx.SaveChangesAsync(ct);
    }
}