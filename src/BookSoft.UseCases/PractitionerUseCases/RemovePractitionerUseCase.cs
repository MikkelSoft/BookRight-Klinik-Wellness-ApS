using BookSoft.Domain.Exceptions;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;

namespace BookSoft.UseCases.PractitionerUseCases
{
    public class RemovePractitionerUseCase : IRemovePractitionerUseCase
    {
        private readonly IPractitionerRepo _practitionerRepo;

        public RemovePractitionerUseCase(IPractitionerRepo practitionerRepo)
        {
            _practitionerRepo = practitionerRepo;
        }

        public async Task Run(Guid practitionerId)
        {
            var practitioner = await _practitionerRepo.GetByIdAsync(practitionerId);
            if (practitioner is null)
                throw new NotFoundException($"Behandler {practitionerId} ikke fundet.");

            await _practitionerRepo.Delete(practitioner);
            await _practitionerRepo.SaveAsync();
        }
    }
}
