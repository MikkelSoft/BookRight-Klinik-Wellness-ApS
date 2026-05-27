using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Entities;
using BookSoft.Infrastructure.Data;
using BookSoft.UseCases.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.Repositories;

public class ClinicRepository : IClinicRepo
{
    private readonly BookSoftDbContext _db;

    public ClinicRepository(BookSoftDbContext db)
    {
        _db = db;
    }

    /*
    // GET all
    public async Task<List<Clinic>> GetAllAsync(CancellationToken ct = default)
    {
        return await _db.Clinics
            .Include(c => c.Practitioners)
            .ToListAsync(ct);
    }
    */
    // GET by Id
    public async Task<Clinic?> GetByIdAsync(Guid id)
    {
        return await _db.Clinics
            .Include(c => c.Practitioners)
            .FirstOrDefaultAsync(c => c.ID == id);
    }

    /*
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
    }*/

    // UPDATE
    public void Update(Clinic clinic) //behøver ikke update i EF
    {
        _db.Clinics.Update(clinic);
    }

    // SAVE
    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}