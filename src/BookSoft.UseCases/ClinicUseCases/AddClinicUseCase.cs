using BookSoft.Domain.Entities;
using BookSoft.Facade.DTOs;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;

namespace BookSoft.UseCases.ClinicUseCases
{
    public class AddClinicUseCase : IAddClinicUseCase
    {
        private readonly IClinicRepo _clinicRepo;

        public AddClinicUseCase(IClinicRepo clinicRepo)
        {
            _clinicRepo = clinicRepo;
        }

        public async Task Run(AddClinicRequest request)
        {
            var clinic = new Clinic(request.ClinicName);
            await _clinicRepo.AddAsync(clinic);
            await _clinicRepo.SaveAsync();
        }
    }
}
