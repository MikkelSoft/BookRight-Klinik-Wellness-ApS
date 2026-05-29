using System;
using System.Threading.Tasks;

namespace BookSoft.Facade.UseCases
{
    /// <summary>
    /// Deletes a patient from the system.
    /// Only takes the patient's Id — no extra data needed to perform a delete.
    /// The use case will throw NotFoundException if the patient does not exist.
    /// </summary>
    public interface IRemovePatientUseCase
    {
        Task Run(Guid patientId);
    }
}
