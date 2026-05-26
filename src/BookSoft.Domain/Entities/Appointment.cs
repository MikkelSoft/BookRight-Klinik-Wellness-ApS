using BookSoft.Domain.Enums;
using System;
using System.Collections.Generic;

namespace BookSoft.Domain.Entities
{
    public class Appointment : AggregateRoot
    {
        public Guid PatientId { get; private set; }
        public Guid PractitionerId { get; private set; }
        public DateTime DateTime { get; private set; }

        public AppointmentStatusEnum Status { get; private set; }
        public AppointmentTypeEnum AppointmentType { get; private set; }

        public virtual Practitioner? Practitioner { get; private set; }
        public virtual Patient? Patient { get; private set; }

        private Appointment() { } //til EF core

        public int AppointmentDuration => AppointmentType switch
        {
            AppointmentTypeEnum.Consultation => 30,
            AppointmentTypeEnum.Checkup => 15,
            AppointmentTypeEnum.Procedure => 60,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}