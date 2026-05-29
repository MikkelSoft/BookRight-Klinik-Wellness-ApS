using BookSoft.Domain.Enums;

namespace BookSoft.Facade.DTOs
{
    public record AddPractitionerRequest(
        string FirstName,
        string MiddleNames,
        string LastName,
        string Email,
        string PhoneNumber,
        string Specialty,
        AutorisationsTypeEnum AutorisationsType
    );
}
