using BookSoft.Domain.Entities;
using BookSoft.Facade.DTOs;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;

namespace BookSoft.UseCases.PractitionerUseCases
{
    /// <summary>
    /// Opretter en ny behandler og gemmer den i databasen.
    /// AutorisationsType bestemmer hvilke behandlinger behandleren må udføre.
    /// </summary>
    public class AddPractitionerUseCase : IAddPractitionerUseCase
    {
        private readonly IPractitionerRepo _practitionerRepo;

        public AddPractitionerUseCase(IPractitionerRepo practitionerRepo)
        {
            _practitionerRepo = practitionerRepo;
        }

        public async Task Run(AddPractitionerRequest request)
        {
            var practitioner = new Practitioner(
                request.FirstName,
                request.MiddleNames,
                request.LastName,
                request.Email,
                request.PhoneNumber,
                request.Specialty,
                request.AutorisationsType
            );

            await _practitionerRepo.AddAsync(practitioner);
            await _practitionerRepo.SaveAsync();
        }
    }
}
