using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Domain.Entities
{
    public class Practitioner : Person
    {
        public virtual List<Appointment> Appointments { get; private set; } = new List<Appointment>();
        public string Specialty { get; private set; } = null!;
        public List<string> PhoneNumbers { get; private set; } = new List<string>();

        public Practitioner(string fullName, string email, string specialty)
        {
            FullName = new FullName(fullName);
            Email = email;
            Specialty = specialty;
        }
    }
}
