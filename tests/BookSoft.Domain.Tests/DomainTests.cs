using BookSoft.Domain.Entities;
using BookSoft.Domain.Enums;

namespace BookSoft.Domain.Tests
{
    public class DomainTests
    {
        // Fremtidig dato så DomainException("aftale i fortiden") ikke kastes
        DateTime b = DateTime.Now.AddDays(1);

        [Fact]
        public void AppointmentTypeToEnumParseTestTrue()
        {
            // Brug et gyldigt behandlingstypnavn fra det nye enum
            decimal pris = Appointment.GetBasePris(AppointmentTypeEnum.Fysioterapi30Min, DateTime.Now.AddDays(1));
            var testing = Appointment.CreateNewAppointment(
                Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
                "Fysioterapi30Min", b, pris);

            Assert.True(testing.AppointmentType == AppointmentTypeEnum.Fysioterapi30Min);
        }

        [Fact]
        public void AppointmentTypeToDurationTest()
        {
            // Fysioterapi30Min varer 30 minutter — sluttid = starttid + 30 min
            decimal pris = Appointment.GetBasePris(AppointmentTypeEnum.Fysioterapi30Min, DateTime.Now.AddDays(1));
            var testing3 = Appointment.CreateNewAppointment(
                Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(),
                "Fysioterapi30Min", b, pris);

            Assert.True(testing3.AppointmentEndTime == testing3.AppointmentStartTime.AddMinutes(30));
        }

        [Fact]
        public void GetBasePris_AftenTillæg_Er15Procent()
        {
            // Aftentid (18:00) skal give 15% tillæg oven på grundprisen (395 kr)
            var aftenTid = new DateTime(2026, 6, 1, 18, 0, 0); // mandag aften
            decimal pris = Appointment.GetBasePris(AppointmentTypeEnum.Fysioterapi30Min, aftenTid);
            Assert.Equal(395m * 1.15m, pris);
        }

        [Fact]
        public void GetBasePris_DagtidHverdagIngenTillæg()
        {
            // Dagtid hverdagsdag (10:00 mandag) — ingen tillæg
            var dagtid = new DateTime(2026, 6, 1, 10, 0, 0); // mandag
            decimal pris = Appointment.GetBasePris(AppointmentTypeEnum.Fysioterapi30Min, dagtid);
            Assert.Equal(395m, pris);
        }
    }
}
