using BookSoft.Domain.Enums;

namespace BookSoft.Facade.DTOs
{
    public record PractitionerDto(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber,
        string Specialty,
        AutorisationsTypeEnum AutorisationsType
    );
}
