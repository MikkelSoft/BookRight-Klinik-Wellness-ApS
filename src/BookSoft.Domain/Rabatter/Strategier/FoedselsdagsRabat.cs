namespace BookSoft.Domain.Rabatter.Strategier
{
    // 25% rabat i patientens fødselsdagsmåned
    public class FoedselsdagsRabat : IRabatBeregner
    {
        public RabatResultat? BeregnRabat(RabatKontekst kontekst)
        {
            if (!kontekst.Patient.HarFoedselsdag(kontekst.BookingDato))
                return null;

            const decimal procent = 0.25m;
            return new RabatResultat("Fødselsdagsmåned (25%)", procent, kontekst.BasisPris * (1 - procent));
        }
    }
}
