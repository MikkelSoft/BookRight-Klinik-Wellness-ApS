using BookSoft.Domain.Entities;
using BookSoft.Domain.Enums;
using BookSoft.Domain.Exceptions;
using BookSoft.Facade.DTOs;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;

namespace BookSoft.UseCases.Appointments
{
    public class CancelAppointmentUseCase : ICancelAppointmentUseCase
    {
        private readonly IAppointmentRepo _appointmentRepo;

        public CancelAppointmentUseCase(IAppointmentRepo appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        public async Task Run(CancelAppointmentRequest request)
        {
            var appointment = await _appointmentRepo.GetByIdAsync(request.AppointmentId);

            if (appointment is null)
                throw new NotFoundException($"Appointment {request.AppointmentId} not found.");

            if (appointment.AppointmentStatus == AppointmentStatusEnum.Cancelled)
                throw new DomainException("Appointment is already cancelled.");

            if (appointment.AppointmentStatus == AppointmentStatusEnum.Completed)
                throw new DomainException("Cannot cancel a completed appointment.");

            appointment.Cancel();

            await _appointmentRepo.SaveAsync();
        }
    }
}