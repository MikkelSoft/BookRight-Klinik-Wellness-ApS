using System;

namespace BookSoft.Facade.DTOs
{
    /// <summary>
    /// Data needed to rename an existing clinic.
    /// Id identifies which clinic to update.
    /// </summary>
    public record UpdateClinicRequest(
        Guid Id,
        string ClinicName
    );
}
