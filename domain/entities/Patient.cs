using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace domain.entities
{
    public enum loyaltyLevel
    {
        None,
        Bronze,
        Silver,
        Gold,
    }
    public class Patient
    {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateOnly Birthday { get; private set; }
        public decimal totalSpend { get; private set; }
        public loyaltyLevel loyaltyLevel => totalSpend switch
        {
            < 1000m => loyaltyLevel.None,
            < 5000m => loyaltyLevel.Bronze,
            < 10000m => loyaltyLevel.Silver,
            _        => loyaltyLevel.Gold,
        };

        public void RecordPayment(decimal amount)
        {
            totalSpend += amount;
        }

        public Patient(string name, string email, DateOnly birthday, decimal totalSpend)
        {
            Name = name;
            Email = email;
            Birthday = birthday;
            this.totalSpend = totalSpend;
        }
    }
}