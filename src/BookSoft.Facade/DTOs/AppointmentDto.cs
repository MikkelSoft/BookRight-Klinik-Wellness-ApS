using BookSoft.Domain.Enums;

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
        decimal Pris,
        string? AnvendtRabatType,
        AppointmentStatusEnum Status
    );
}
