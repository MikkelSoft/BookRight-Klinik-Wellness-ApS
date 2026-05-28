using BookSoft.Facade.DTOs;
using BookSoft.Facade.Queries;
using BookSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.QueryHandlers
{
    public class CampaignQueriesImp : ICampaignQueries
    {
        private readonly BookSoftDbContext _db;

        public CampaignQueriesImp(BookSoftDbContext db) => _db = db;

        public async Task<IReadOnlyList<CampaignDto>> GetAllAsync()
        {
            var campaigns = await _db.Campaigns
                .AsNoTracking()
                .OrderBy(c => c.StartDato)
                .ToListAsync();

            return campaigns.Select(c => new CampaignDto(
                c.ID,
                c.Navn,
                c.StartDato,
                c.SlutDato,
                c.DiscountProcent,
                c.ValidFor.Select(t => t.ToString()).ToList()
            )).ToList();
        }
    }
}
