using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Facade.UseCases
{
    public interface ICreateNewAppointmentUseCase
    {
        Task Run(CreateNewAppointmentRequest request);
    }
}
