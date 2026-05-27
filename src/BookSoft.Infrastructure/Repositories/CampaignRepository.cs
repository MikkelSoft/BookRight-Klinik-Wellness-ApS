using BookSoft.Domain.Entities;
using BookSoft.Infrastructure.Data;
using BookSoft.UseCases.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BookSoft.Infrastructure.Repositories;

public class CampaignRepository : ICampaignRepo
{
    private readonly BookSoftDbContext _db;

    public CampaignRepository(BookSoftDbContext db)
    {
        _db = db;
    }

    // henter alle kampagner der er aktive på datoen
    public async Task<IReadOnlyList<Campaign>> GetAktiveAsync(DateTime dato)
    {
        return await _db.Campaigns
            .Where(k => k.StartDato.Date <= dato.Date && k.SlutDato.Date >= dato.Date)
            .ToListAsync();
    }

    public async Task AddAsync(Campaign campaign)
    {
        await _db.Campaigns.AddAsync(campaign);
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}
