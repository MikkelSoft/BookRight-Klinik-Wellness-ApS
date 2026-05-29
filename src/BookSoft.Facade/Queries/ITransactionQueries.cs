using BookSoft.Facade.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSoft.Facade.Queries
{
    /// <summary>
    /// Read-only queries for Transaction data.
    /// Transactions are created automatically when FinishAppointmentUseCase runs —
    /// these queries are only for reading payment history, not creating records.
    /// </summary>
    public interface ITransactionQueries
    {
        /// <summary>Returns all transactions. Used for the Financials overview page.</summary>
        Task<IReadOnlyList<TransactionDto>> GetAllAsync();

        /// <summary>Returns all transactions for a specific patient. Used for the patient's payment history tab.</summary>
        Task<IReadOnlyList<TransactionDto>> GetByPatientIdAsync(Guid patientId);

        /// <summary>Returns a single transaction by Id, or null if not found.</summary>
        Task<TransactionDto?> GetByIdAsync(Guid id);
    }
}
