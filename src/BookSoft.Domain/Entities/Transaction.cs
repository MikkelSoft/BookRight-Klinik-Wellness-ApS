using BookSoft.Domain.Enums;
using BookSoft.Domain.Exceptions;

namespace BookSoft.Domain.Entities
{
    // registrerer en betaling når en aftale afsluttes
    public class Transaction : AggregateRoot
    {
        public Guid PatientId { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public TransactionStatus Status { get; private set; }
        public AppointmentTypeEnum AppointmentType { get; private set; }

        // det faktiske beløb patienten betalte (efter rabat)
        public decimal Beloeb { get; private set; }

        // alias så FinishAppointmentUseCase stadig kan bruge .cost
        public decimal cost => Beloeb;

        public virtual Patient? Patient { get; private set; } = null!;
        public virtual Campaign? Campaign { get; private set; } = null!;

        private Transaction() { } // ef core

        private Transaction(Guid patientId, AppointmentTypeEnum appointmentType, decimal beloeb)
        {
            PatientId = patientId != Guid.Empty ? patientId : throw new DomainException("PatientId mangler.");
            AppointmentType = appointmentType;
            Beloeb = beloeb > 0 ? beloeb : throw new DomainException("Beløb skal være større end nul.");
            TransactionDate = DateTime.Now;
            Status = TransactionStatus.Completed;
        }

        // opretter en transaktion med den endelige pris (inkl rabat og tillæg)
        public static Transaction Create(Guid patientId, AppointmentTypeEnum appointmentType, decimal beloeb)
            => new Transaction(patientId, appointmentType, beloeb);
    }
}
