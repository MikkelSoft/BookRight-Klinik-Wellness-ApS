using BookSoft.Domain.Exceptions;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;
using System;
using System.Threading.Tasks;

namespace BookSoft.UseCases.ClinicUseCases
{
    /// <summary>
    /// Removes a clinic from the system.
    ///
    /// Flow:
    ///   1. Confirm the clinic exists (throws NotFoundException otherwise).
    ///   2. Stage the delete via the repository.
    ///   3. Persist.
    /// </summary>
    public class RemoveClinicUseCase : IRemoveClinicUseCase
    {
        private readonly IClinicRepo _clinicRepo;

        public RemoveClinicUseCase(IClinicRepo clinicRepo)
        {
            _clinicRepo = clinicRepo;
        }

        public async Task Run(Guid clinicId)
        {
            // Guard: make sure the clinic exists before deleting it
            var clinic = await _clinicRepo.GetByIdAsync(clinicId);
            if (clinic is null)
                throw new NotFoundException($"Clinic {clinicId} not found.");

            await _clinicRepo.DeleteAsync(clinicId);
            await _clinicRepo.SaveAsync();
        }
    }
}
