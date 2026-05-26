using BookSoft.Domain.Entities;
using BookSoft.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Domain.Tests
{
    public class DomainTests
    {
        //koden er meget uoptimal her :D men whatever det er bare unit tests tihi! -- mikkel
        DateTime b = DateTime.Now.AddDays(1);

        [Fact]
        public void AppointmentTypeToEnumParseTestTrue()
        {
            var testing = Appointment.CreateNewAppointment(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "Consultation", b);
            Assert.True(testing.AppointmentType == AppointmentTypeEnum.Consultation);
        }
        
        [Fact]
        public void AppointmentTypeToDurationTest()
        {
            var testing3 = Appointment.CreateNewAppointment(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), "Consultation", b);
            Assert.True(testing3.AppointmentEndTime == testing3.AppointmentStartTime.AddMinutes(30));
        }
    }
}
