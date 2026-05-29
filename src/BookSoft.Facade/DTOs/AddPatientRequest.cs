namespace BookSoft.Facade.DTOs
{
    public record AddPatientRequest(
        string FirstName,
        string MiddleNames,
        string LastName,
        string Email,
        string PhoneNumber,
        DateTime Birthday
    );
}
