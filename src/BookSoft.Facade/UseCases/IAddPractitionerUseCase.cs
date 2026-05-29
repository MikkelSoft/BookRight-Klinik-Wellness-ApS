// BookSoft.Facade/UseCases/IAddPractitionerUseCase.cs

using BookSoft.Facade.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Facade.UseCases
{
    public interface IAddPractitionerUseCase
    {
        Task Run(AddPractitionerRequest request);
    }
}