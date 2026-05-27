using BookSoft.Domain.Enums;

namespace BookSoft.Facade.DTOs
{
    /// <summary>
    /// Felterne der kan ændres når en behandler redigeres.
    /// AutorisationsType er inkluderet — en behandler kan skifte faglig autorisering.
    /// </summary>
    public record UpdatePractitionerRequest(
        Guid Id,
        string FirstName,
        string MiddleNames,
        string LastName,
        string Email,
        string PhoneNumber,
        string Specialty,
        AutorisationsTypeEnum AutorisationsType
    );
}
