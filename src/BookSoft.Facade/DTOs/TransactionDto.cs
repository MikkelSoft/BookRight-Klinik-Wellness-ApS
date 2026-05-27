using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Facade.DTOs
{
    /// <summary>
    /// Read-only snapshot of a Transaction, used for displaying payment history.
    /// Transactions are created automatically when FinishAppointmentUseCase runs —
    /// they are never created directly through the UI.
    /// </summary>
    public record TransactionDto(
        Guid Id,
        Guid PatientId,
        string PatientFullName,   // e.g. "Jane Doe" — pre-joined for display, avoids extra lookups
        string AppointmentType,   // "Consultation", "Checkup", or "Procedure"
        decimal Cost,             // calculated from AppointmentType in the domain
        string Status,            // "Completed", "Pending", etc. — stringified TransactionStatus enum
        DateTime TransactionDate  // when the transaction was recorded
    );
}
