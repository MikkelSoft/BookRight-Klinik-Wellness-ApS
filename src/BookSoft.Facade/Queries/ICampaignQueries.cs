using BookSoft.Facade.DTOs;

namespace BookSoft.Facade.Queries
{
    public interface ICampaignQueries
    {
        Task<IReadOnlyList<CampaignDto>> GetAllAsync();
    }
}
