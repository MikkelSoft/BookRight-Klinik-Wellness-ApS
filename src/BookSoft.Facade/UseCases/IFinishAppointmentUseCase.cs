using BookSoft.Facade.DTOs;

namespace BookSoft.Facade.UseCases
{
    public interface IFinishAppointmentUseCase
    {
        Task Run(Guid appointmentId);
    }
}