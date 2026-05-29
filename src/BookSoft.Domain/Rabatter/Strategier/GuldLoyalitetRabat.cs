using BookSoft.Domain.Enums;

namespace BookSoft.Domain.Rabatter.Strategier
{
    // 15% rabat til guld kunder (købt for 25000+ kr de seneste 12 mdr)
    public class GuldLoyalitetRabat : IRabatBeregner
    {
        public RabatResultat? BeregnRabat(RabatKontekst kontekst)
        {
            if (kontekst.Patient.BeregnLoyalitetsNiveau(kontekst.BookingDato) != LoyaltyLevelEnum.Gold)
                return null;

            const decimal procent = 0.15m;
            return new RabatResultat("Guld-loyalitet (15%)", procent, kontekst.BasisPris * (1 - procent));
        }
    }
}
