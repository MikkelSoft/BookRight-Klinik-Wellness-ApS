using BookSoft.Facade.DTOs;
using System;
using System.Collections.Generic;
using System.Text;


namespace BookSoft.Facade.UseCases
{
    public interface IAddPatientUseCase
    {
        Task Run(AddPatientRequest request);
    }
}
