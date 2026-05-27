using BookSoft.Domain.Enums;
using BookSoft.Domain.Exceptions;

namespace BookSoft.Domain.Entities
{
    public class Appointment : AggregateRoot
    {
        public Guid PatientId { get; private set; }
        public Guid PractitionerId { get; private set; }
        public Guid ClinicId { get; private set; }

        /// <summary>String-repræsentation af AppointmentType — gemt for nem visning i UI.</summary>
        public string AppointmentTypeString { get; private set; } = string.Empty;

        public DateTime AppointmentStartTime { get; private set; }
        public DateTime AppointmentEndTime { get; private set; }
        public bool PaymentStatus { get; private set; }
        public AppointmentStatusEnum AppointmentStatus { get; private set; }
        public AppointmentTypeEnum AppointmentType { get; private set; }

        /// <summary>Endelig pris efter bedste rabat er anvendt.</summary>
        public decimal Pris { get; private set; }

        /// <summary>
        /// Hvilken rabattype der blev anvendt, f.eks. "Bronze-loyalitet" eller "Fødselsdagsmåned".
        /// Null hvis ingen rabat var relevant.
        /// </summary>
        public string? AnvendtRabatType { get; private set; }

        // Navigation properties — loaded by EF when needed
        public virtual Practitioner? Practitioner { get; private set; }
        public virtual Patient? Patient { get; private set; }
        public virtual Clinic? Clinic { get; private set; }

        public void Cancel()
        {
            if (AppointmentStatus == AppointmentStatusEnum.Cancelled)
                throw new DomainException("Aftalen er allerede aflyst.");

            if (AppointmentStatus == AppointmentStatusEnum.Completed)
                throw new DomainException("En afsluttet aftale kan ikke aflyses.");

            AppointmentStatus = AppointmentStatusEnum.Cancelled;
        }

        public void Complete()
        {
            if (AppointmentStatus == AppointmentStatusEnum.Completed)
                throw new DomainException("Aftalen er allerede afsluttet.");

            if (AppointmentStatus == AppointmentStatusEnum.Cancelled)
                throw new DomainException("En aflyst aftale kan ikke afsluttes.");

            AppointmentStatus = AppointmentStatusEnum.Completed;
        }

        private Appointment() { } // krævet af EF Core

        private Appointment(Guid patientId, Guid practitionerId, Guid clinicId,
            string appointmentTypeString, DateTime appointmentStartTime,
            decimal pris, string? anvendtRabatType)
        {
            PatientId = patientId != Guid.Empty ? patientId : throw new DomainException("PatientId mangler.");
            PractitionerId = practitionerId != Guid.Empty ? practitionerId : throw new DomainException("PractitionerId mangler.");
            ClinicId = clinicId != Guid.Empty ? clinicId : throw new DomainException("ClinicId mangler.");

            AppointmentTypeString = appointmentTypeString;

            // Parse typen først — bruges i varighed-switchen nedenfor
            AppointmentType = Enum.Parse<AppointmentTypeEnum>(AppointmentTypeString, true);

            AppointmentStartTime = appointmentStartTime;
            AppointmentEndTime = appointmentStartTime.AddMinutes(GetDuration(AppointmentType));

            AppointmentStatus = AppointmentStatusEnum.Scheduled;

            Pris = pris;
            AnvendtRabatType = anvendtRabatType;

            if (AppointmentStartTime < DateTime.Now)
                throw new DomainException("En aftale kan ikke oprettes i fortiden.");
        }

        /// <summary>
        /// Opretter en ny aftale med den beregnede pris og eventuel rabattype.
        /// Kaldes fra CreateNewAppointmentUseCase efter rabatberegning.
        /// </summary>
        public static Appointment CreateNewAppointment(
            Guid patientId, Guid practitionerId, Guid clinicId,
            string appointmentTypeString, DateTime appointmentStartTime,
            decimal pris, string? anvendtRabatType = null)
        {
            return new Appointment(patientId, practitionerId, clinicId,
                appointmentTypeString, appointmentStartTime, pris, anvendtRabatType);
        }

        /// <summary>
        /// Returnerer varighed i minutter for den givne behandlingstype.
        /// Static så use casen kan beregne sluttidspunkt til dobbeltbooking-tjek
        /// inden selve aftalen oprettes.
        /// </summary>
        public static int GetDuration(AppointmentTypeEnum type) => type switch
        {
            AppointmentTypeEnum.Fysioterapi30Min            => 30,
            AppointmentTypeEnum.Fysioterapi45Min            => 45,
            AppointmentTypeEnum.Fysioterapi60Min            => 60,
            AppointmentTypeEnum.Sportsmassage30Min          => 30,
            AppointmentTypeEnum.Sportsmassage60Min          => 60,
            AppointmentTypeEnum.Akupunktur45Min             => 45,
            AppointmentTypeEnum.KostvejledningFoerste       => 60,
            AppointmentTypeEnum.KostvejledningOpfoelgning   => 30,
            AppointmentTypeEnum.Holdtraening60Min           => 60,
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };

        /// <summary>
        /// Returnerer basisprisen for den givne behandlingstype.
        /// Tillægger 15% aftens-/weekendtillæg automatisk.
        /// Static så use casen kan beregne prisen inden rabatstrategierne køres.
        /// </summary>
        public static decimal GetBasePris(AppointmentTypeEnum type, DateTime startTime)
        {
            // Grundpris fra prislisten i opgavebeskrivelsen
            decimal grundpris = type switch
            {
                AppointmentTypeEnum.Fysioterapi30Min            => 395m,
                AppointmentTypeEnum.Fysioterapi45Min            => 589m,
                AppointmentTypeEnum.Fysioterapi60Min            => 745m,
                AppointmentTypeEnum.Sportsmassage30Min          => 350m,
                AppointmentTypeEnum.Sportsmassage60Min          => 699m,
                AppointmentTypeEnum.Akupunktur45Min             => 550m,
                AppointmentTypeEnum.KostvejledningFoerste       => 799m,
                AppointmentTypeEnum.KostvejledningOpfoelgning   => 450m,
                AppointmentTypeEnum.Holdtraening60Min           => 150m, // pr. deltager
                _ => throw new ArgumentOutOfRangeException(nameof(type))
            };

            // 15% tillæg på aften (17:00+) og weekendbookinger
            bool erAften = startTime.Hour >= 17;
            bool erWeekend = startTime.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;

            return erAften || erWeekend
                ? grundpris * 1.15m
                : grundpris;
        }
    }
}
