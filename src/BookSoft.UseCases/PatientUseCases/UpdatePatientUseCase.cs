using BookSoft.Domain.Exceptions;
using BookSoft.Facade.DTOs;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;

namespace BookSoft.UseCases.PatientUseCases
{
    public class UpdatePatientUseCase : IUpdatePatientUseCase
    {
        private readonly IPatientRepo _patientRepo;

        public UpdatePatientUseCase(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task Run(UpdatePatientRequest request)
        {
            var patient = await _patientRepo.GetByIdAsync(request.Id);
            if (patient is null)
                throw new NotFoundException($"Patient {request.Id} ikke fundet.");

            patient.UpdateDetails(
                request.FirstName,
                request.MiddleNames,
                request.LastName,
                request.Email,
                request.PhoneNumber,
                request.Birthday
            );

            _patientRepo.Update(patient);
            await _patientRepo.SaveAsync();
        }
    }
}
