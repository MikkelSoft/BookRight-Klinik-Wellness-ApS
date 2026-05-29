using BookSoft.Facade.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Facade.UseCases
{
    public interface ICancelAppointmentUseCase
    {
        Task Run(CancelAppointmentRequest request);
    }
}
