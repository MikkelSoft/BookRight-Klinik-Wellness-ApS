using BookSoft.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Domain.Entities
{
    public class Transactions : AggregateRoot
    {
        public DateTime TransactionDate { get; private set; }
        public AppointmentType AppointmentType { get; private set; }
        public Practitioner Practitioners { get; private set; }
        public FullName PractiionerName => Practitioners.FullName;

        public decimal cost => AppointmentType switch
        {
            AppointmentType.Consultation => 300,
            AppointmentType.Checkup => 200,
            AppointmentType.Procedure => 600,
            _ => throw new ArgumentOutOfRangeException()
        };

    }
}
