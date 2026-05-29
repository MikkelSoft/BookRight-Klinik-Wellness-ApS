using BookSoft.Facade.DTOs;

namespace BookSoft.Facade.UseCases
{
    public interface IAddCampaignUseCase
    {
        Task Run(AddCampaignRequest request);
    }
}
