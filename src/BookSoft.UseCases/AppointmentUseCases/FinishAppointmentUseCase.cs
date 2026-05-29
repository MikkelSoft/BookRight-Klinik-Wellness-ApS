using BookSoft.Domain.Entities;
using BookSoft.Domain.Exceptions;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;

namespace BookSoft.UseCases.AppointmentUseCases
{
    public class FinishAppointmentUseCase : IFinishAppointmentUseCase
    {
        private readonly IAppointmentRepo _appointmentRepo;
        private readonly IPatientRepo _patientRepo;
        private readonly ITransactionRepo _transactionRepo;

        public FinishAppointmentUseCase(IAppointmentRepo appointmentRepo, IPatientRepo patientRepo, ITransactionRepo transactionRepo)
        {
            _appointmentRepo = appointmentRepo;
            _patientRepo = patientRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task Run(Guid appointmentId)
        {
            var aftale = await _appointmentRepo.GetByIdAsync(appointmentId);
            if (aftale is null)
                throw new NotFoundException($"Aftale {appointmentId} ikke fundet.");

            var patient = await _patientRepo.GetByIdAsync(aftale.PatientId);
            if (patient is null)
                throw new NotFoundException($"Patient {aftale.PatientId} ikke fundet.");

            aftale.Complete();

            // brug prisen fra aftalen - den er allerede beregnet med rabat ved booking
            var transaktion = Transaction.Create(patient.ID, aftale.AppointmentType, aftale.Pris);
            patient.RecordPayment(transaktion.cost);

            await _transactionRepo.AddAsync(transaktion);
            await _appointmentRepo.SaveAsync();
        }
    }
}
