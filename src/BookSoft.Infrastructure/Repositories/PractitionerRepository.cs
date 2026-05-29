using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Entities;
using BookSoft.Infrastructure.Data;
using BookSoft.UseCases.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.Repositories;

public class PractitionerRepository : IPractitionerRepo
{
    private readonly BookSoftDbContext _db;

    public PractitionerRepository(BookSoftDbContext db)
    {
        _db = db;
    }

    // GET all
   
    public async Task<List<Practitioner>> GetAllAsync(CancellationToken ct = default)
    {
        return await _db.Practitioners
            .Include(p => p.Appointments)
            .ToListAsync(ct);
    }

    // GET by Id
    public async Task<Practitioner?> GetByIdAsync(Guid id)
    {
        return await _db.Practitioners
            .Include(p => p.Appointments)
            .FirstOrDefaultAsync(p => p.ID == id);
    }
    
    // GET by specialty
    public async Task<List<Practitioner>> GetBySpecialtyAsync(string specialty, CancellationToken ct = default)
    {
        return await _db.Practitioners
            .Where(p => p.Specialty.ToLower() == specialty.ToLower())
            .Include(p => p.Appointments)
            .ToListAsync(ct);
    }

    // GET available on a given date (no appointment clashes)
    public async Task<List<Practitioner>> GetAvailableAsync(DateTime date, CancellationToken ct = default)
    {
        return await _db.Practitioners
            .Include(p => p.Appointments)
            .Where(p => p.Appointments.All(a => a.AppointmentStartTime.Date != date.Date))
            .ToListAsync(ct);
    }

    // CREATE
    public async Task AddAsync(Practitioner practitioner, CancellationToken ct = default)
    {
        await _db.Practitioners.AddAsync(practitioner, ct);
    }
    

    // UPDATE //behøves ik
    public void Update(Practitioner practitioner)
    {
        _db.Practitioners.Update(practitioner);
    }

    // SAVE
    public async Task SaveAsync(CancellationToken ct = default)
    {
        await _db.SaveChangesAsync(ct);
    }

    //Delete
    public async Task Delete(Practitioner practitioner)
    {
        _db.Practitioners.Remove(practitioner);
    }
}