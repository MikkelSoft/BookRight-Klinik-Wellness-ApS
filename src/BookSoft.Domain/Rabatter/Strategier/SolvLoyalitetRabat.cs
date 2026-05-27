using BookSoft.Domain.Enums;

namespace BookSoft.Domain.Rabatter.Strategier
{
    // 10% rabat til sølv kunder (købt for 10000+ kr de seneste 12 mdr)
    public class SolvLoyalitetRabat : IRabatBeregner
    {
        public RabatResultat? BeregnRabat(RabatKontekst kontekst)
        {
            if (kontekst.Patient.BeregnLoyalitetsNiveau(kontekst.BookingDato) != LoyaltyLevelEnum.Silver)
                return null;

            const decimal procent = 0.10m;
            return new RabatResultat("Sølv-loyalitet (10%)", procent, kontekst.BasisPris * (1 - procent));
        }
    }
}
