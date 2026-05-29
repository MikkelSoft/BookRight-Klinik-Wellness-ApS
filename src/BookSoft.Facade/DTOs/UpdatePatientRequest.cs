using System;

namespace BookSoft.Facade.DTOs
{
    /// <summary>
    /// Carries the fields a user can change when editing an existing patient.
    /// Id is required so the use case knows which patient to load from the DB.
    /// TotalSpent and LoyaltyLevel are intentionally excluded — they are derived
    /// from payment history and must never be set manually.
    /// </summary>
    public record UpdatePatientRequest(
        Guid Id,
        string FirstName,
        string MiddleNames,
        string LastName,
        string Email,
        string PhoneNumber,
        DateTime Birthday
    );
}
