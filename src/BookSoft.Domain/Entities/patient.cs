using System;
using System.Collections.Generic;
using System.Text;

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
        public virtual List<Transactions> Transactions { get; private set; } = new List<Transactions>(); //have not fully implemented transactions class yet
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
        public Patient(string fullName, string email, DateTime birthday)
        {
            FullName = new FullName(fullName);
            Email = email;
            Birthday = birthday;
        }

        private Patient() { }
    }
}
