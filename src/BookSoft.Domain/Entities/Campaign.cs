using BookSoft.Domain.Enums;

namespace BookSoft.Domain.Entities
{
    // En tidsbegrænset kampagne der giver rabat på udvalgte behandlingstyper.
    // Eksempel: "Forårskampagne: 20% på massage i april".
    // Kampagner oprettes af administrationen og bruges af KampagneRabat-strategien.
    public class Campaign : AggregateRoot
    {
        public string Navn { get; private set; } = null!;
        public DateTime StartDato { get; private set; }
        public DateTime SlutDato { get; private set; }

        //Rabatprocent som decimaltal — f.eks. 0.20 for 20%.
        public decimal DiscountProcent { get; private set; }
        public virtual List<Transaction> Transactions { get; private set; } = new();

		// Hvilke behandlingstyper kampagnen gælder for.
		// Gemt som en primitiv samling i EF Core (separat tabel).
		// Tom liste = gælder for alle behandlingstyper.
		public List<AppointmentTypeEnum> ValidFor { get; private set; } = new();

        // Krævet af EF Core
        private Campaign() { }

        public Campaign(string navn, DateTime startDato, DateTime slutDato, decimal rabatProcent, List<AppointmentTypeEnum> gælderFor)
        {
            Navn = navn;
            StartDato = startDato;
            SlutDato = slutDato;
            DiscountProcent = rabatProcent;
            ValidFor = gælderFor;
        }

        /// <summary>Returnerer true hvis kampagnen er aktiv på den givne dato.</summary>
        public bool ErAktiv(DateTime dato) =>
            dato.Date >= StartDato.Date && dato.Date <= SlutDato.Date;

        /// <summary>
        /// Returnerer true hvis kampagnen gælder for den givne behandlingstype.
        /// Hvis ValidFor er tom gælder den for alle behandlingstyper.
        /// </summary>
        public bool ValidForBehandling(AppointmentTypeEnum type) =>
            !ValidFor.Any() || ValidFor.Contains(type);
    }
}
