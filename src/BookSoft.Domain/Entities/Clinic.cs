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

        private Clinic() { }

        public Clinic(string clinicName)
        {
            ClinicName = clinicName;
        }
    }
}
