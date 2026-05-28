using BookSoft.Domain.Enums;

namespace BookSoft.Facade.DTOs
{
    public record AddCampaignRequest(
        string Navn,
        DateTime StartDato,
        DateTime SlutDato,
        decimal DiscountProcent,
        List<AppointmentTypeEnum> ValidFor
    );
}
