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
        public virtual List<Transaction> Transactions { get; private set; } = new List<Transaction>(); //have not fully implemented transactions class yet
        public DateTime Birthday { get; private set; } //datetime virker i sql, det gør dateonly ikke
        public decimal TotalSpent { get; private set; }

        public void RecordPayment(decimal amount)
        {
            TotalSpent += amount;
        }
        public loyaltyLevel LoyaltyLevel => TotalSpent switch //skal det her laves til en enum?
        {
            >= 10000 => loyaltyLevel.Gold,
            >= 5000 => loyaltyLevel.Silver,
            >= 1000 => loyaltyLevel.Bronze,
            _ => loyaltyLevel.None
        };
        public Patient(string firstName, string middleNames, string lastName, string email, string phoneNumber, DateTime birthday, decimal totalSpent) : base(firstName, middleNames, lastName, email, phoneNumber)
        {
            Birthday = birthday;  //base : gør så dette child af parent person bruger constructoren i base, altså parent class
        }
    }
}
