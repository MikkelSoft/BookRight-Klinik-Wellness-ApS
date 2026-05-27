using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Facade.DTOs
{
    public record AppointmentDto(Guid Id, Guid PatientId, Guid PractitionerId, Guid ClinicId, string AppointmentTypeString, DateTime AppointmentStartTime, DateTime AppointmentEndTime, string PatientFullNameString, string PractitionerFullNameString, string ClinicName);

}
