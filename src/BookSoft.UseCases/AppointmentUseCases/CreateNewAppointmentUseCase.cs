using BookSoft.Domain.Entities;
using BookSoft.Facade.DTOs;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookSoft.UseCases.Appointments
{
    public class CreateNewAppointmentUseCase : ICreateNewAppointmentUseCase
    {
        private readonly IAppointmentRepo _appointmentRepo;
        private readonly IPatientRepo _patientRepo;
        private readonly IPractitionerRepo _practitionerRepo;

        public CreateNewAppointmentUseCase(IAppointmentRepo appointmentRepo, IPatientRepo patientRepo, IPractitionerRepo practitionerRepo)
        {
            _appointmentRepo = appointmentRepo;
            _patientRepo = patientRepo;
            _practitionerRepo = practitionerRepo;
        }

        public async Task Run(CreateNewAppointmentRequest request)
        {
            //skal implementeres nogle exceptions

            var patientBookings = await _appointmentRepo.GetByPatientIdAsync(request.PatientId);
            var practitionerBookings = await _appointmentRepo.GetByPractitionerIdAsync(request.PractitionerId); //skal implementeres videre så der ikke kommer nogen overlap

            string appointmentTypeString = request.AppointmentTypeString;
            DateTime appointmentStartTime = request.AppointmentStartTime;
            var appointment = Appointment.CreateNewAppointment(request.PatientId, request.PractitionerId, request.ClinicId, appointmentTypeString, appointmentStartTime);

            await _appointmentRepo.AddAsync(appointment);
            await _appointmentRepo.SaveAsync();
        }
    }
}
