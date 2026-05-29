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

    public async Task<List<Clinic>> GetAllAsync()
    {
        return await _db.Clinics
            .Include(c => c.Practitioners)
            .ToListAsync();
    }

    public async Task<Clinic?> GetByIdAsync(Guid id)
    {
        return await _db.Clinics
            .Include(c => c.Practitioners)
            .FirstOrDefaultAsync(c => c.ID == id);
    }

    public async Task AddAsync(Clinic clinic)
    {
        await _db.Clinics.AddAsync(clinic);
    }

    public void Update(Clinic clinic)
    {
        _db.Clinics.Update(clinic);
    }

    public async Task DeleteAsync(Guid id)
    {
        var clinic = await _db.Clinics.FindAsync(id);
        if (clinic is not null)
            _db.Clinics.Remove(clinic);
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}
