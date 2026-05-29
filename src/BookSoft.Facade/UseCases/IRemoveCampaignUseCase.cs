namespace BookSoft.Facade.UseCases
{
    public interface IRemoveCampaignUseCase
    {
        Task Run(Guid campaignId);
    }
}
