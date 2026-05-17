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


        //FullName constructor takes 3 params (firstName, middleNames, lastName)
        //but Patient and Practitioner pass a single fullName string — that will break
        public FullName(string firstName, string middleNames, string lastName)
        {
            FirstName = firstName;
            MiddleNames = middleNames;
            LastName = lastName;
        }
    }
}
