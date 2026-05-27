using BookSoft.Facade.DTOs;
using System.Threading.Tasks;

namespace BookSoft.Facade.UseCases
{
    /// <summary>
    /// Renames an existing clinic.
    /// The use case will throw NotFoundException if the clinic does not exist.
    /// </summary>
    public interface IUpdateClinicUseCase
    {
        Task Run(UpdateClinicRequest request);
    }
}
