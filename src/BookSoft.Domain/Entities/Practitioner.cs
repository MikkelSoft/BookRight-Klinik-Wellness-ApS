using BookSoft.Domain.Enums;
using BookSoft.Domain.Exceptions;
using BookSoft.Domain.ValueObjects;

namespace BookSoft.Domain.Entities
{
    public class Practitioner : Person
    {
        public virtual List<Appointment> Appointments { get; private set; } = new();
        public virtual List<Clinic> Clinics { get; private set; } = new();

        public string Specialty { get; protected set; } = null!;

        // autorisationstype styrer hvilke behandlinger behandleren må lave
        public AutorisationsTypeEnum AutorisationsType { get; private set; }

        private Practitioner() { } // kræves af ef core

        public Practitioner(string firstName, string middleNames, string lastName,
                            string email, string phoneNumber,
                            string specialty, AutorisationsTypeEnum autorisationsType)
            : base(firstName, middleNames, lastName, email, phoneNumber)
        {
            Specialty = specialty;
            AutorisationsType = autorisationsType;
        }

        // tjekker om behandleren er autoriseret til den givne behandlingstype
        public bool KanUdfoereBehandling(AppointmentTypeEnum type) => AutorisationsType switch
        {
            AutorisationsTypeEnum.Fysioterapeut =>
                type is AppointmentTypeEnum.Fysioterapi30Min
                     or AppointmentTypeEnum.Fysioterapi45Min
                     or AppointmentTypeEnum.Fysioterapi60Min
                     or AppointmentTypeEnum.Holdtraening60Min,

            AutorisationsTypeEnum.Massoer =>
                type is AppointmentTypeEnum.Sportsmassage30Min
                     or AppointmentTypeEnum.Sportsmassage60Min,

            AutorisationsTypeEnum.Akupunktoer =>
                type is AppointmentTypeEnum.Akupunktur45Min,

            AutorisationsTypeEnum.Kostvejleder =>
                type is AppointmentTypeEnum.KostvejledningFoerste
                     or AppointmentTypeEnum.KostvejledningOpfoelgning,

            _ => throw new ArgumentOutOfRangeException(nameof(AutorisationsType))
        };

        public void UpdateDetails(string firstName, string middleNames, string lastName,
                                  string email, string phoneNumber,
                                  string specialty, AutorisationsTypeEnum autorisationsType)
        {
            FullName = new FullName(firstName, middleNames, lastName);
            Email = email;
            PhoneNumber = phoneNumber;
            Specialty = specialty;
            AutorisationsType = autorisationsType;
        }
    }
}
