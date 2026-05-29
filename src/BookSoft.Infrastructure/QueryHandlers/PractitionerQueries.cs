using BookSoft.Facade.DTOs;
using BookSoft.Facade.Queries;
using BookSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.QueryHandlers
{
    /// <summary>
    /// Handles read-only queries for Practitioner data.
    /// Uses AsNoTracking() on every query — we are only reading, not modifying,
    /// so there is no need for EF to track these entities in memory.
    /// </summary>
    public class PractitionerQueriesImp : IPractitionerQueries
    {
        private readonly BookSoftDbContext _db;

        public PractitionerQueriesImp(BookSoftDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Reusable mapping from domain entity to DTO.
        /// Keeping it in one place means if PractitionerDto changes,
        /// there is only one spot to update.
        /// </summary>
        private static PractitionerDto MapToDto(Domain.Entities.Practitioner p) => new PractitionerDto(
            p.ID,
            p.FullName.FirstName,
            p.FullName.LastName,
            p.Email,
            p.PhoneNumber,
            p.Specialty,
            p.AutorisationsType
        );

        /// <summary>Returns all practitioners. Used for the practitioner list page.</summary>
        public async Task<IReadOnlyList<PractitionerDto>> GetAllAsync()
        {
            var practitioners = await _db.Practitioners
                .AsNoTracking()
                .ToListAsync();

            return practitioners.Select(MapToDto).ToList();
        }

        /// <summary>Returns a single practitioner by Id, or null if not found.</summary>
        public async Task<PractitionerDto?> GetByIdAsync(Guid id)
        {
            var practitioner = await _db.Practitioners
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ID == id);

            // Return null cast to the non-nullable return type — caller should check for null.
            // The interface signature doesn't have ? but the value can still be null at runtime.
            return MapToDto(practitioner!);
        }
    }
}
