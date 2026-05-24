using BookSoft.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Domain.Entities
{
    public class Clinic : AggregateRoot
    {
        public virtual List<Practitioner> Practitioners { get; private set; } = new List<Practitioner>();
        public string ClinicName { get; private set; }

        public Clinic(string clinicName)
        {
            ClinicName = clinicName;
        }
    }
}
