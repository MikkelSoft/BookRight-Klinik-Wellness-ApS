using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.ValueObjects;

namespace BookSoft.Domain.Entities
{
    public enum loyaltyLevel
    {
        None,
        Bronze,
        Silver,
        Gold
    }
    public class Patient : Person
    {
        public virtual List<Appointment> Appointments { get; private set; } = new List<Appointment>();
        public DateTime Birthday { get; private set; } //datetime?
        public List<string> PhoneNumbers { get; private set; } = new List<string>();
        public virtual List<Transaction> Transactions { get; private set; } = new List<Transaction>(); //have not fully implemented transactions class yet
        public decimal TotalSpent { get; private set; }

        public void RecordPayment(decimal amount)
        {
            TotalSpent += amount;
        }
        public loyaltyLevel LoyaltyLevel => TotalSpent switch
        {
            >= 10000 => loyaltyLevel.Gold,
            >= 5000 => loyaltyLevel.Silver,
            >= 1000 => loyaltyLevel.Bronze,
            _ => loyaltyLevel.None
        };
        public Patient(string firstName, string middleNames, string lastName, string email, DateTime birthday)
        {
            FullName = new FullName(firstName, middleNames, lastName);
            Email = email;
            Birthday = birthday;
        }

        private Patient() { }
    }
}
