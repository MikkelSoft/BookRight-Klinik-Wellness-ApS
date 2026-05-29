using BookSoft.Domain.Enums;

namespace BookSoft.Domain.Rabatter.Strategier
{
    // 5% rabat til bronze kunder (købt for 3000+ kr de seneste 12 mdr)
    public class BronzeLoyalitetRabat : IRabatBeregner
    {
        public RabatResultat? BeregnRabat(RabatKontekst kontekst)
        {
            if (kontekst.Patient.BeregnLoyalitetsNiveau(kontekst.BookingDato) != LoyaltyLevelEnum.Bronze)
                return null;

            const decimal procent = 0.05m;
            return new RabatResultat("Bronze-loyalitet (5%)", procent, kontekst.BasisPris * (1 - procent));
        }
    }
}
