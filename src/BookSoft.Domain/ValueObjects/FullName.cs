using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Domain.ValueObjects
{
    public class FullName
    {
        public string FirstName { get; private set; }
        public string MiddleNames { get; private set; }
        public string LastName { get; private set; }

        public FullName(string firstName, string middleNames, string lastName)
        {
            FirstName = firstName;
            MiddleNames = middleNames;
            LastName = lastName;
        }
    }
}
