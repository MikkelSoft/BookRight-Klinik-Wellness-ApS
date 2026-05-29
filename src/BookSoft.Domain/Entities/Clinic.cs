using BookSoft.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Domain.Entities
{
    public class Clinic : AggregateRoot
    {
        public string ClinicName { get; private set; } = string.Empty;

        public virtual List<Practitioner> Practitioners { get; private set; } = new List<Practitioner>();
        public virtual List<Appointment> Appointments { get; private set; } = new List<Appointment>();

        private Clinic() { }

        public Clinic(string clinicName)
        {
            ClinicName = clinicName;
        }

        /// Renames the clinic.
        /// Called by UpdateClinicUseCase when an admin changes the clinic's display name.
        public void UpdateName(string clinicName)
        {
            ClinicName = clinicName;
        }
    }
}
