using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Facade.DTOs;

namespace BookSoft.Facade.UseCases
{
    public interface ICreateNewAppointmentUseCase
    {
        Task Run(CreateNewAppointmentRequest request);
    }
}
