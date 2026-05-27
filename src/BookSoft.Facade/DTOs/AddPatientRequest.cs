using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Facade.DTOs
{
    // BookSoft.Facade/DTOs/AddPatientRequest.cs
    namespace BookSoft.Facade.DTOs
    {
        public record AddPatientRequest(
            string FirstName,
            string MiddleNames,
            string LastName,
            string Email,
            string PhoneNumber,
            DateTime Birthday
        );
    }
}
