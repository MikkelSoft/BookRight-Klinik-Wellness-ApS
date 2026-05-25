using BookSoft.Facade.DTOs;

namespace BookSoft.Facade.Interfaces
{
    //all methods are in async so that the program doesnt stop while waiting for the database to respond
    public interface IAppointmentRepository
    {
        // GET
        Task<List<AppointmentDto>> GetAllAsync();
        Task<AppointmentDto> GetByIdAsync(int id);
        Task<List<AppointmentDto>> GetByPatientIdAsync(int patientId);
        Task<List<AppointmentDto>> GetByPractitionerIdAsync(int practitionerId);

        // CREATE
        Task AddAsync(AppointmentDto appointment);

        // UPDATE
        Task UpdateAsync(AppointmentDto appointment);

        // DELETE
        Task DeleteAsync(AppointmentDto appointment);

        // SAVE - EF Core needs this to commit changes to the database
        Task SaveChangesAsync();
    }
}