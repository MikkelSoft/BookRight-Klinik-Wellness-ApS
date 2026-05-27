using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Entities;
using BookSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.Repositories;

public class PatientRepository
{
    private readonly BookSoftDbContext _db;

    public PatientRepository(BookSoftDbContext db)
    {
        _db = db;
    }

    // GET all
    public async Task<List<Patient>> GetAllAsync(CancellationToken ct = default)
    {
        return await _db.Patients
            .Include(p => p.Appointments)
            .ToListAsync(ct);
    }

    // GET by Id
    public async Task<Patient?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _db.Patients
            .Include(p => p.Appointments)
            .FirstOrDefaultAsync(p => p.ID == id, ct);
    }

    // GET by name (searches first or last name)
    public async Task<List<Patient>> GetByNameAsync(string name, CancellationToken ct = default)
    {
        var lower = name.ToLower();
        return await _db.Patients
            .Where(p => p.FullName.FirstName.ToLower().Contains(lower)
                     || p.FullName.MiddleNames.ToLower().Contains(lower)
                     || p.FullName.LastName.ToLower().Contains(lower))
            .ToListAsync(ct);
    }

    // CREATE
    public async Task AddAsync(Patient patient, CancellationToken ct = default)
    {
        await _db.Patients.AddAsync(patient, ct);
    }

    // UPDATE
    public void Update(Patient patient)
    {
        _db.Patients.Update(patient);
    }

    // DELETE
    public void Delete(Patient patient)
    {
        _db.Patients.Remove(patient);
    }

    // SAVE
    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await _db.SaveChangesAsync(ct);
    }
}