namespace BookSoft.Facade.DTOs
{
    public record AppointmentDto(
        Guid Id,
        Guid PatientId,
        Guid PractitionerId,
        Guid ClinicId,
        string AppointmentTypeString,
        DateTime AppointmentStartTime,
        DateTime AppointmentEndTime,
        string PatientFullNameString,
        string PractitionerFullNameString,
        string ClinicName,
        decimal Pris,               // endelig pris efter rabat og tillæg
        string? AnvendtRabatType    // fx "Bronze-loyalitet (5%)" eller null hvis ingen rabat
    );
}
