using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Entities;
using BookSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.Repositories;

public class ClinicRepository
{
    private readonly BookSoftDbContext _db;

    public ClinicRepository(BookSoftDbContext db)
    {
        _db = db;
    }

    // GET all
    public async Task<List<Clinic>> GetAllAsync(CancellationToken ct = default)
    {
        return await _db.Clinics
            .Include(c => c.Practitioners)
            .ToListAsync(ct);
    }

    // GET by Id
    public async Task<Clinic?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return await _db.Clinics
            .Include(c => c.Practitioners)
            .FirstOrDefaultAsync(c => c.ID == id, ct);
    }

    // GET by name
    public async Task<Clinic?> GetByNameAsync(string name, CancellationToken ct = default)
    {
        return await _db.Clinics
            .FirstOrDefaultAsync(c => c.ClinicName.ToLower() == name.ToLower(), ct);
    }

    // CREATE
    public async Task AddAsync(Clinic clinic, CancellationToken ct = default)
    {
        await _db.Clinics.AddAsync(clinic, ct);
    }

    // UPDATE
    public void Update(Clinic clinic)
    {
        _db.Clinics.Update(clinic);
    }

    // DELETE
    public void Delete(Clinic clinic)
    {
        _db.Clinics.Remove(clinic);
    }

    // SAVE
    public async Task SaveChangesAsync(CancellationToken ct = default)
    {
        await _db.SaveChangesAsync(ct);
    }
}