using BookSoft.Domain.Enums;
using System;
using System.Collections.Generic;
using BookSoft.Domain.Exceptions;
using System.Security.Cryptography.X509Certificates;

namespace BookSoft.Domain.Entities
{
    public class Appointment : AggregateRoot
    {
        public Guid PatientId { get; private set; }
        public Guid PractitionerId { get; private set; }
        public Guid ClinicId { get; private set; }
        public string AppointmentTypeString { get; private set; } = string.Empty;
        public DateTime AppointmentStartTime { get; private set; }
        public DateTime AppointmentEndTime { get; private set; }
        public bool PaymentStatus { get; private set; }
        public AppointmentStatusEnum AppointmentStatus { get; private set; }
        public AppointmentTypeEnum AppointmentType { get; private set; }

        //opretter virtuelle objekter til EF
        public virtual Practitioner? Practitioner { get; private set; }
        public virtual Patient? Patient { get; private set; }
        public virtual Clinic? Clinic { get; private set; }

        public void Cancel()
        {
            if (AppointmentStatus == AppointmentStatusEnum.Cancelled)
            {
                throw new DomainException("The appointment is already cancelled.");
            }
            if (AppointmentStatus == AppointmentStatusEnum.Completed)
            {
                throw new DomainException("You can not cancel completed appointments.");
            }
            AppointmentStatus = AppointmentStatusEnum.Cancelled;
        }

        private Appointment() { } //til EF core

        private Appointment(Guid patientId, Guid practitionerId, Guid clinicId, string appointmentTypeString, DateTime appointmentStartTime) //private constructor tvinger den til at bruge factory method
        {
            PatientId = patientId != Guid.Empty ? patientId : throw new DomainException("PatientId is missing.");
            PractitionerId = practitionerId != Guid.Empty ? practitionerId : throw new DomainException("PractitionerId is missing.");
            ClinicId = clinicId != Guid.Empty ? clinicId : throw new DomainException("ClinicId is missing.");
            AppointmentTypeString = appointmentTypeString;

            AppointmentStartTime = appointmentStartTime;
            AppointmentEndTime = appointmentStartTime.AddMinutes(
                AppointmentType switch
            {
                AppointmentTypeEnum.Consultation => 30,
                AppointmentTypeEnum.Checkup => 15,
                AppointmentTypeEnum.Procedure => 60,
                _ => throw new ArgumentOutOfRangeException()
            });
            AppointmentStatus = AppointmentStatusEnum.Scheduled;

            AppointmentType = Enum.Parse<AppointmentTypeEnum>(AppointmentTypeString, true); //parser stringen appointmenttypestring til enum

            if (AppointmentEndTime < DateTime.Now)
            {
                throw new DomainException("You can not schedule appointments in the past.");
            }
        }

        public static Appointment CreateNewAppointment(Guid patientId, Guid practitionerId, Guid clinicId, string appointmentTypeString, DateTime appointmentStartTime) //factory metode
        {
            var appointment = new Appointment(patientId, practitionerId, clinicId, appointmentTypeString, appointmentStartTime);
            return appointment;
        }
    }
}