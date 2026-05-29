namespace BookSoft.Facade.DTOs
{
    public record CampaignDto(
        Guid Id,
        string Navn,
        DateTime StartDato,
        DateTime SlutDato,
        decimal DiscountProcent,   // 0.20 = 20%
        List<string> ValidFor      // empty = gælder alle behandlingstyper
    );
}
