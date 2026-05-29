using BookSoft.Domain.Entities;
using BookSoft.Facade.DTOs;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;

namespace BookSoft.UseCases.CampaignUseCases
{
    public class AddCampaignUseCase : IAddCampaignUseCase
    {
        private readonly ICampaignRepo _campaigns;

        public AddCampaignUseCase(ICampaignRepo campaigns) => _campaigns = campaigns;

        public async Task Run(AddCampaignRequest request)
        {
            var campaign = new Campaign(
                request.Navn,
                request.StartDato,
                request.SlutDato,
                request.DiscountProcent,
                request.ValidFor
            );

            await _campaigns.AddAsync(campaign);
            await _campaigns.SaveAsync();
        }
    }
}
