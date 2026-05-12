using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Domain.Entities
{
    public class Patient : Person
    {
        public virtual List<Appointment> Appointments { get; private set; } = new List<Appointment>();
        public string Birthday { get; private set; } = null!; //datetime?
    }
}
