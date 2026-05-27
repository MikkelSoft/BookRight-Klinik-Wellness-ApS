using BookSoft.Facade.DTOs;
using System.Threading.Tasks;

namespace BookSoft.Facade.UseCases
{
    /// <summary>
    /// Registers a new clinic in the system.
    /// After this runs the clinic can be selected when booking appointments.
    /// </summary>
    public interface IAddClinicUseCase
    {
        Task Run(AddClinicRequest request);
    }
}
