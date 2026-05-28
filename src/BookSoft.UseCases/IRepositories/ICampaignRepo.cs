using BookSoft.Domain.Entities;

namespace BookSoft.UseCases.IRepositories
{
    public interface ICampaignRepo
    {
        Task<IReadOnlyList<Campaign>> GetAllAsync();
        Task<IReadOnlyList<Campaign>> GetAktiveAsync(DateTime dato);
        Task AddAsync(Campaign campaign);
        Task DeleteAsync(Guid id);
        Task SaveAsync();
    }
}
