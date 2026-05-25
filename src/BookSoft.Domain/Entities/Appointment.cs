using System;
using System.Collections.Generic;

namespace BookSoft.Domain.Entities
{
    public enum AppointmentStatus
    {
        Scheduled,
        Completed,
        Canceled
    }

    public enum AppointmentType
    {
        Consultation,
        Checkup,
        Procedure
    }

    public class Appointment : AggregateRoot
    {
        public Guid PatientId { get; private set; }
        public Guid PractitionerId { get; private set; }
        public DateTime Date { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public AppointmentType AppointmentType { get; private set; }

        public virtual List<Practitioner> Practitioners { get; private set; } = new List<Practitioner>();
        public virtual Patient? Patient { get; private set; }

        public int AppointmentDuration => AppointmentType switch
        {
            AppointmentType.Consultation => 30,
            AppointmentType.Checkup => 15,
            AppointmentType.Procedure => 60,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}