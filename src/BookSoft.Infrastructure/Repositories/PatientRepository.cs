using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Entities;
using BookSoft.Infrastructure.Data;
using BookSoft.UseCases.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.Repositories;

public class PatientRepository : IPatientRepo
{
    private readonly BookSoftDbContext _db;

    public PatientRepository(BookSoftDbContext db)
    {
        _db = db;
    }
    // GET all
    public async Task<List<Patient>> GetAllAsync()
    {
        return await _db.Patients
            .Include(p => p.Appointments)
            .ToListAsync();
    }
    // GET by Id
    public async Task<Patient?> GetByIdAsync(Guid id)
    {
        return await _db.Patients
            .Include(p => p.Appointments)
            .FirstOrDefaultAsync(p => p.ID == id);
    }

    //GET by name(searches first or last name)
    public async Task<List<Patient>> GetByNameAsync(string name)
    {
        var lower = name.ToLower();
        return await _db.Patients
            .Where(p => p.FullName.FirstName.ToLower().Contains(lower)
                     || p.FullName.MiddleNames.ToLower().Contains(lower)
                     || p.FullName.LastName.ToLower().Contains(lower))
            .ToListAsync();
    }

    //CREATE
    public async Task AddAsync(Patient patient)
    {
        await _db.Patients.AddAsync(patient);
    }
    
    // UPDATE //behøver ikke update
    public void Update(Patient patient)
    {
        _db.Patients.Update(patient);
    }

    // SAVE
    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
    // DELETE
    public async Task DeleteAsync(Guid id)
    {
        var patient = await GetByIdAsync(id);
        if (patient != null)
        {
            _db.Patients.Remove(patient);
            await SaveAsync();
        }
    }
}