using BookSoft.Domain.Entities;
using BookSoft.Facade.DTOs;
using BookSoft.Facade.DTOs.BookSoft.Facade.DTOs;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookSoft.UseCases.PatientUseCases
{
    public class AddPatientUseCase : IAddPatientUseCase
    {
        private readonly IPatientRepo _patientRepo;

        public AddPatientUseCase(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task Run(AddPatientRequest request)
        {
            var patient = new Patient(
                request.FirstName,
                request.MiddleNames,
                request.LastName,
                request.Email,
                request.PhoneNumber,
                request.Birthday,
                0
            );

            await _patientRepo.AddAsync(patient);
            await _patientRepo.SaveAsync();
        }
    }
}