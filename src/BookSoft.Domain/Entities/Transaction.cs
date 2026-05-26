using BookSoft.Domain.Enums;
using BookSoft.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Domain.Entities
{
    public class Transaction : AggregateRoot
    {
        public Guid PatientGuid { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public AppointmentTypeEnum AppointmentType { get; private set; }
        public virtual Patient Patient { get; private set; } = null!;

        public decimal cost => AppointmentType switch
        {
            AppointmentTypeEnum.Consultation => 300,
            AppointmentTypeEnum.Checkup => 200,
            AppointmentTypeEnum.Procedure => 600,
            _ => throw new ArgumentOutOfRangeException()
        };

    }
}
