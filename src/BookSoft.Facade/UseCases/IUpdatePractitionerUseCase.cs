using BookSoft.Facade.DTOs;
using System.Threading.Tasks;

namespace BookSoft.Facade.UseCases
{
    /// <summary>
    /// Updates an existing practitioner's details (name, email, phone, specialty).
    /// The use case will throw NotFoundException if the practitioner does not exist.
    /// </summary>
    public interface IUpdatePractitionerUseCase
    {
        Task Run(UpdatePractitionerRequest request);
    }
}
