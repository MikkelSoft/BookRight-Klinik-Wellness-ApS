using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;

namespace BookSoft.UseCases.CampaignUseCases
{
    public class RemoveCampaignUseCase : IRemoveCampaignUseCase
    {
        private readonly ICampaignRepo _campaigns;

        public RemoveCampaignUseCase(ICampaignRepo campaigns) => _campaigns = campaigns;

        public async Task Run(Guid campaignId)
        {
            await _campaigns.DeleteAsync(campaignId);
            await _campaigns.SaveAsync();
        }
    }
}
