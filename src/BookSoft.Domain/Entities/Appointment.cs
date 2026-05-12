using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Domain.Entities
{
    public class Appointment : AggregateRoot
    {
        public virtual List<Practitioner> Practitioners { get; private set; } = new List<Practitioner>();
        public virtual Patient? Patient { get; private set; }
    }
}
