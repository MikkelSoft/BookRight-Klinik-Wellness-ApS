using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Facade.DTOs
{
    public record CreateNewAppointmentRequest(Guid PatientId, Guid PractitionerId, Guid ClinicId, string AppointmentTypeString, DateTime AppointmentStartTime);
}
