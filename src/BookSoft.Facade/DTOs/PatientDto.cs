using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Facade.DTOs
{
    public record PatientDto(
        Guid Id,
        string FirstName,
        string LastName,
        DateTime Birthday,
        string Email,
        string PhoneNumber,
        decimal TotalSpent,
        string LoyaltyLevel);
}