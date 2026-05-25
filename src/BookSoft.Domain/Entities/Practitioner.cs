using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.ValueObjects;

namespace BookSoft.Domain.Entities
{
    public class Practitioner : Person
    {
        public virtual List<Appointment> Appointments { get; private set; } = new List<Appointment>();
        public virtual List<Clinic> Clinics { get; private set; } = new List<Clinic>();
        public string Specialty { get; private set; } = null!;

        public Practitioner(string firstName, string middleNames, string lastName, string email, string specialty)
        {
            FullName = new FullName(firstName, middleNames, lastName);
            Email = email;
            Specialty = specialty;
        }
    }
}
