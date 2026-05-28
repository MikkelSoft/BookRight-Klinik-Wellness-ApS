namespace BookSoft.Domain.Rabatter
{
    // resultatet fra en enkelt strategi
    // RabatService sammenligner alle resultater og tager den med laveste pris
    public record RabatResultat(
        string RabatType,      // fx "Bronze-loyalitet (5%)"
        decimal DiscountProcent,  // fx 0.05
        decimal PrisEfterRabat
    );
}
