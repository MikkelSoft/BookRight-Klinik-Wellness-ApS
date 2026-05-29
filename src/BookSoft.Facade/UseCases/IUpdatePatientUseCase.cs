using BookSoft.Facade.DTOs;
using System.Threading.Tasks;

namespace BookSoft.Facade.UseCases
{
    /// <summary>
    /// Updates an existing patient's details (name, email, phone, birthday).
    /// Payment-related fields (TotalSpent, LoyaltyLevel) are not changeable here —
    /// they are derived from transaction history.
    /// The use case will throw NotFoundException if the patient does not exist.
    /// </summary>
    public interface IUpdatePatientUseCase
    {
        Task Run(UpdatePatientRequest request);
    }
}
