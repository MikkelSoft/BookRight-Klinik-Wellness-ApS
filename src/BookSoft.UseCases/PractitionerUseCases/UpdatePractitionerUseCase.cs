using BookSoft.Domain.Exceptions;
using BookSoft.Facade.DTOs;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;
using System.Threading.Tasks;

namespace BookSoft.UseCases.PractitionerUseCases
{
    /// <summary>
    /// Updates an existing practitioner's details (name, contact, specialty).
    ///
    /// Flow:
    ///   1. Load the practitioner from the DB (throws NotFoundException if missing).
    ///   2. Call UpdateDetails() on the domain entity to apply the changes.
    ///   3. Mark the entity as modified (EF change tracking).
    ///   4. Persist.
    /// </summary>
    public class UpdatePractitionerUseCase : IUpdatePractitionerUseCase
    {
        private readonly IPractitionerRepo _practitionerRepo;

        public UpdatePractitionerUseCase(IPractitionerRepo practitionerRepo)
        {
            _practitionerRepo = practitionerRepo;
        }

        public async Task Run(UpdatePractitionerRequest request)
        {
            // Load the tracked entity so EF can detect and save the changes
            var practitioner = await _practitionerRepo.GetByIdAsync(request.Id);
            if (practitioner is null)
                throw new NotFoundException($"Practitioner {request.Id} not found.");

            // Anvend de opdaterede værdier via domænemetoden
            practitioner.UpdateDetails(
                request.FirstName,
                request.MiddleNames,
                request.LastName,
                request.Email,
                request.PhoneNumber,
                request.Specialty,
                request.AutorisationsType
            );

            // Mark as modified so EF includes it in the next SaveChanges call
            _practitionerRepo.Update(practitioner);
            await _practitionerRepo.SaveAsync();
        }
    }
}
