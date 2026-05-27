// BookSoft.Infrastructure/QueryHandlers/PatientQueries.cs

using BookSoft.Facade.DTOs;
using BookSoft.Facade.Queries;
using BookSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.QueryHandlers
{
    public class PatientQueriesImp : IPatientQueries
    {
        private readonly BookSoftDbContext _db;

        public PatientQueriesImp(BookSoftDbContext db)
        {
            _db = db;
        }

        public async Task<IReadOnlyList<PatientDto>> GetAllAsync()
        {
            var patients = await _db.Patients
                .AsNoTracking()
                .ToListAsync();

            return patients.Select(p => new PatientDto(
                p.ID,
                p.FullName.FirstName,
                p.FullName.LastName,
                p.Birthday,
                p.Email,
                p.PhoneNumber,
                p.TotalSpent,
                p.loyaltyLevel.ToString()
            )).ToList();
        }

        public async Task<PatientDto?> GetByIdAsync(Guid id)
        {
            var patient = await _db.Patients
                .AsNoTracking()
                .Where(p => p.ID == id)
                .FirstOrDefaultAsync();

            if (patient is null) return null;

            return new PatientDto(
                patient.ID,
                patient.FullName.FirstName,
                patient.FullName.LastName,
                patient.Birthday,
                patient.Email,
                patient.PhoneNumber,
                patient.TotalSpent,
                patient.loyaltyLevel.ToString()
            );
        }
        }
    }
