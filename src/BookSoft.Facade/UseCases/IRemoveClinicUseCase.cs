using System;
using System.Threading.Tasks;

namespace BookSoft.Facade.UseCases
{
    /// <summary>
    /// Deletes a clinic from the system.
    /// The use case will throw NotFoundException if the clinic does not exist.
    /// </summary>
    public interface IRemoveClinicUseCase
    {
        Task Run(Guid clinicId);
    }
}
