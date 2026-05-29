using BookSoft.Domain.Exceptions;
using BookSoft.Facade.DTOs;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;

namespace BookSoft.UseCases.ClinicUseCases
{
    public class UpdateClinicUseCase : IUpdateClinicUseCase
    {
        private readonly IClinicRepo _clinicRepo;

        public UpdateClinicUseCase(IClinicRepo clinicRepo)
        {
            _clinicRepo = clinicRepo;
        }

        public async Task Run(UpdateClinicRequest request)
        {
            var clinic = await _clinicRepo.GetByIdAsync(request.Id);
            if (clinic is null)
                throw new NotFoundException($"Klinik {request.Id} ikke fundet.");

            clinic.UpdateName(request.ClinicName);
            _clinicRepo.Update(clinic);
            await _clinicRepo.SaveAsync();
        }
    }
}
