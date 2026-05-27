using BookSoft.Domain.Exceptions;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;

namespace BookSoft.UseCases.PatientUseCases
{
    public class RemovePatientUseCase : IRemovePatientUseCase
    {
        private readonly IPatientRepo _patientRepo;

        public RemovePatientUseCase(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task Run(Guid patientId)
        {
            var patient = await _patientRepo.GetByIdAsync(patientId);
            if (patient is null)
                throw new NotFoundException($"Patient {patientId} ikke fundet.");

            await _patientRepo.DeleteAsync(patientId);
            await _patientRepo.SaveAsync();
        }
    }
}
