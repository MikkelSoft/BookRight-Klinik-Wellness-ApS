using BookSoft.Domain.Enums;
using BookSoft.Domain.ValueObjects;

namespace BookSoft.Domain.Entities
{
    public class Patient : Person
    {
        public DateTime Birthday { get; protected set; }

        // total amount spent - bruges til loyality
        public decimal TotalSpent { get; private set; }

        public virtual List<Appointment> Appointments { get; private set; } = new();
        public virtual List<Transaction> Transactions { get; private set; } = new();

        private Patient() { } // ef core kræver denne

        public Patient(string firstName, string middleNames, string lastName,
                       string email, string phoneNumber, DateTime birthday,
                       decimal totalSpent = 0)
            : base(firstName, middleNames, lastName, email, phoneNumber)
        {
            Birthday = birthday;
            TotalSpent = totalSpent;
        }

        // tilføjer beløb når en aftale er færdig
        public void RecordPayment(decimal amount)
        {
            TotalSpent += amount;
        }

        // beregner loyalitetsniveau ud fra de seneste 12 måneder
        // HUSK: transactions skal være loaded (include) inden dette kaldes ellers får man 0
        public LoyaltyLevelEnum BeregnLoyalitetsNiveau(DateTime nu)
        {
            var grænse = nu.AddMonths(-12);

            decimal seneste12Mdr = Transactions
                .Where(t => t.TransactionDate >= grænse)
                .Sum(t => t.Beloeb);

            return seneste12Mdr switch
            {
                >= 25_000m => LoyaltyLevelEnum.Gold,
                >= 10_000m => LoyaltyLevelEnum.Silver,
                >= 3_000m  => LoyaltyLevelEnum.Bronze,
                _          => LoyaltyLevelEnum.None
            };
        }

        // hurtig version uden db kald - til UI visning (baseret på TotalSpent)
        public LoyaltyLevelEnum loyaltyLevel => TotalSpent switch
        {
            >= 25_000m => LoyaltyLevelEnum.Gold,
            >= 10_000m => LoyaltyLevelEnum.Silver,
            >= 3_000m  => LoyaltyLevelEnum.Bronze,
            _          => LoyaltyLevelEnum.None
        };

        // returnere true hvis patienten har fødselsdag denne måned
        public bool HarFoedselsdag(DateTime nu) => Birthday.Month == nu.Month;

        // opdater patient info - totalspent ændres ikke her
        public void UpdateDetails(string firstName, string middleNames, string lastName,
                                  string email, string phoneNumber, DateTime birthday)
        {
            FullName = new FullName(firstName, middleNames, lastName);
            Email = email;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
        }
    }
}
