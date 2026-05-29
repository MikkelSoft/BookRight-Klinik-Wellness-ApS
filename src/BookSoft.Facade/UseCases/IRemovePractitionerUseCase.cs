using System;
using System.Threading.Tasks;

namespace BookSoft.Facade.UseCases
{
    /// <summary>
    /// Removes a practitioner from the system.
    /// The use case will throw NotFoundException if the practitioner does not exist.
    /// </summary>
    public interface IRemovePractitionerUseCase
    {
        Task Run(Guid practitionerId);
    }
}
