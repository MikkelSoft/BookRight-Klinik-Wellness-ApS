using BookSoft.Domain.Entities;
using BookSoft.Facade.DTOs;
using BookSoft.Facade.Queries;
using BookSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.QueryHandlers
{
    /// <summary>
    /// Handles read-only queries for Transaction data.
    /// Transactions are created automatically by FinishAppointmentUseCase —
    /// these handlers are only for reading payment history.
    /// </summary>
    public class TransactionQueriesImp : ITransactionQueries
    {
        private readonly BookSoftDbContext _db;

        public TransactionQueriesImp(BookSoftDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Maps a Transaction entity to a TransactionDto.
        /// Includes the patient's full name for display — avoids a second DB call
        /// by joining through the navigation property (loaded via Include).
        /// </summary>
        private static TransactionDto MapToDto(Transaction t) => new TransactionDto(
            t.ID,
            t.PatientId,
            // Build the patient's display name from the FullName value object
            string.Join(" ", t.Patient!.FullName.FirstName, t.Patient.FullName.MiddleNames, t.Patient.FullName.LastName).Trim(),
            t.AppointmentType.ToString(),   // "Consultation", "Checkup", or "Procedure"
            t.cost,                          // calculated from AppointmentType in the domain
            t.Status.ToString(),             // "Completed", "Pending", or "Cancelled"
            t.TransactionDate
        );

        /// <summary>
        /// Returns all transactions ordered by most recent first.
        /// Used for the Financials overview page.
        /// </summary>
        public async Task<IReadOnlyList<TransactionDto>> GetAllAsync()
        {
            var transactions = await _db.Transactions
                .AsNoTracking()
                .Include(t => t.Patient) // needed for patient name in DTO
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();

            return transactions.Select(MapToDto).ToList();
        }

        /// <summary>
        /// Returns all transactions for a specific patient, newest first.
        /// Used for the patient's payment history tab.
        /// </summary>
        public async Task<IReadOnlyList<TransactionDto>> GetByPatientIdAsync(Guid patientId)
        {
            var transactions = await _db.Transactions
                .AsNoTracking()
                .Where(t => t.PatientId == patientId)
                .Include(t => t.Patient)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();

            return transactions.Select(MapToDto).ToList();
        }

        /// <summary>Returns a single transaction by Id, or null if not found.</summary>
        public async Task<TransactionDto?> GetByIdAsync(Guid id)
        {
            var transaction = await _db.Transactions
                .AsNoTracking()
                .Include(t => t.Patient)
                .FirstOrDefaultAsync(t => t.ID == id);

            if (transaction is null) return null;

            return MapToDto(transaction);
        }
    }
}
