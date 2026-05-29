namespace BookSoft.Domain.Rabatter
{
    // strategy interface - hver rabattype implementerer denne
    // RabatService kalder alle og vælger den bedste
    public interface IRabatBeregner
    {
        // returnere null hvis strategien ikke er relevant for denne patient/booking
        RabatResultat? BeregnRabat(RabatKontekst kontekst);
    }
}
