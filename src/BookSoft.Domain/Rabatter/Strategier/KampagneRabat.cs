namespace BookSoft.Domain.Rabatter.Strategier
{
    // finder den bedste aktive kampagne for behandlingstypen og returnere rabatten
    public class KampagneRabat : IRabatBeregner
    {
        public RabatResultat? BeregnRabat(RabatKontekst kontekst)
        {
            // find aktive kampagner der gælder for denne behandlingstype, tag den med højest rabat
            var bedsteKampagne = kontekst.AktiveKampagner
                .Where(k => k.ErAktiv(kontekst.BookingDato) && k.ValidForBehandling(kontekst.BehandlingsType))
                .OrderByDescending(k => k.DiscountProcent)
                .FirstOrDefault();

            if (bedsteKampagne is null)
                return null;

            decimal pris = kontekst.BasisPris * (1 - bedsteKampagne.DiscountProcent);
            return new RabatResultat($"Kampagne: {bedsteKampagne.Navn} ({bedsteKampagne.DiscountProcent * 100:0}%)", bedsteKampagne.DiscountProcent, pris);
        }
    }
}
