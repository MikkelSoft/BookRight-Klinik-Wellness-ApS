using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BookSoft.Domain.ValueObjects;

namespace BookSoft.Domain.Entities
{
    public class Person : AggregateRoot
    {
        // protected set — subclasses (Patient, Practitioner) need to update
        // these when UpdateDetails() is called. Private set would prevent that.
        public FullName FullName {  get; protected set; } = null!;
        public string Email { get; protected set; } = null!;
        public string PhoneNumber { get; protected set; } = null!;

     
        protected Person() { }

        public Person(string firstName, string middleNames, string lastName, string email, string phoneNumber)
        {
            FullName = new FullName(firstName, middleNames, lastName);
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
