using BookSoft.Facade.DTOs;
using BookSoft.Facade.Queries;
using BookSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.QueryHandlers
{
    public class ClinicQueriesImp : IClinicQueries
    {
        private readonly BookSoftDbContext _db;

        public ClinicQueriesImp(BookSoftDbContext db)
        {
            _db = db;
        }

        private static ClinicDto MapToDto(Domain.Entities.Clinic c) => new ClinicDto(
            c.ID,
            c.ClinicName,
            c.Practitioners.Count
        );

        public async Task<IReadOnlyList<ClinicDto>> GetAllAsync()
        {
            var clinics = await _db.Clinics
                .AsNoTracking()
                .Include(c => c.Practitioners)
                .ToListAsync();

            return clinics.Select(MapToDto).ToList();
        }

        public async Task<ClinicDto?> GetByIdAsync(Guid id)
        {
            var clinic = await _db.Clinics
                .AsNoTracking()
                .Include(c => c.Practitioners)
                .FirstOrDefaultAsync(c => c.ID == id);

            if (clinic is null) return null;

            return MapToDto(clinic);
        }
    }
}
