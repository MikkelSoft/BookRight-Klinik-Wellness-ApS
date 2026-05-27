using BookSoft.Domain.Entities;
using BookSoft.Domain.Enums;
using BookSoft.Domain.Exceptions;
using BookSoft.Domain.Rabatter;
using BookSoft.Facade.DTOs;
using BookSoft.Facade.UseCases;
using BookSoft.UseCases.IRepositories;

namespace BookSoft.UseCases.Appointments
{
    public class CreateNewAppointmentUseCase : ICreateNewAppointmentUseCase
    {
        private readonly IAppointmentRepo _appointmentRepo;
        private readonly IPatientRepo _patientRepo;
        private readonly IPractitionerRepo _practitionerRepo;
        private readonly ICampaignRepo _campaignRepo;
        private readonly RabatService _rabatService;

        public CreateNewAppointmentUseCase(
            IAppointmentRepo appointmentRepo,
            IPatientRepo patientRepo,
            IPractitionerRepo practitionerRepo,
            ICampaignRepo campaignRepo,
            RabatService rabatService)
        {
            _appointmentRepo = appointmentRepo;
            _patientRepo = patientRepo;
            _practitionerRepo = practitionerRepo;
            _campaignRepo = campaignRepo;
            _rabatService = rabatService;
        }

        public async Task Run(CreateNewAppointmentRequest request)
        {
            // parse behandlingstypen fra string
            if (!Enum.TryParse<AppointmentTypeEnum>(request.AppointmentTypeString, true, out var behandlingsType))
                throw new DomainException($"Ukendt behandlingstype: '{request.AppointmentTypeString}'.");

            var patient = await _patientRepo.GetByIdAsync(request.PatientId);
            if (patient is null)
                throw new NotFoundException($"Patient {request.PatientId} ikke fundet.");

            var behandler = await _practitionerRepo.GetByIdAsync(request.PractitionerId);
            if (behandler is null)
                throw new NotFoundException($"Behandler {request.PractitionerId} ikke fundet.");

            // tjek om behandleren er autoriseret til denne behandlingstype
            if (!behandler.KanUdfoereBehandling(behandlingsType))
                throw new DomainException(
                    $"Behandler {behandler.FullName.FirstName} {behandler.FullName.LastName} " +
                    $"er ikke autoriseret til {behandlingsType}.");

            var start = request.AppointmentStartTime;
            var slut = start.AddMinutes(Appointment.GetDuration(behandlingsType));

            // dobbeltbooking tjek
            if (await _appointmentRepo.HasClashAsync(request.PractitionerId, start, slut))
                throw new DomainException($"Behandler er allerede booket i tidsrummet {start:HH:mm}–{slut:HH:mm}.");

            // beregn basispris inkl evt aftens/weekendtillæg
            decimal basisPris = Appointment.GetBasePris(behandlingsType, start);

            // hent aktive kampagner og kør rabat strategierne
            var aktiveKampagner = await _campaignRepo.GetAktiveAsync(start);

            var kontekst = new RabatKontekst(patient, behandlingsType, basisPris, start, aktiveKampagner);
            var (endeligPris, anvendtRabatType) = _rabatService.BeregnBedsteRabat(kontekst);

            var aftale = Appointment.CreateNewAppointment(
                request.PatientId, request.PractitionerId, request.ClinicId,
                request.AppointmentTypeString, start, endeligPris, anvendtRabatType);

            await _appointmentRepo.AddAsync(aftale);
            await _appointmentRepo.SaveAsync();
        }
    }
}
