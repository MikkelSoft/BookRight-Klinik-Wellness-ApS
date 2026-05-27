using BookSoft.Domain.Entities;

namespace BookSoft.UseCases.IRepositories
{
    public interface ICampaignRepo
    {
        // henter kampagner der er aktive på den givne dato
        Task<IReadOnlyList<Campaign>> GetAktiveAsync(DateTime dato);
        Task AddAsync(Campaign campaign);
        Task SaveAsync();
    }
}
