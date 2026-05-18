using BookSoft.Facade.DTOs;

namespace BookSoft.Facade.Interfaces
{
    //all methods are in async so that the program doesnt stop while waiting for the database to respond
    public interface IAppointmentRepository
    {
        // GET
        Task<List<Appointment>> GetAllAsync();
        Task<Appointment> GetByIdAsync(int id);
        Task<List<Appointment>> GetByPatientIdAsync(int patientId);
        Task<List<Appointment>> GetByPractitionerIdAsync(int practitionerId);

        // CREATE
        Task AddAsync(Appointment appointment);

        // UPDATE
        Task UpdateAsync(Appointment appointment);

        // DELETE
        Task DeleteAsync(Appointment appointment);

        // SAVE - EF Core needs this to commit changes to the database
        Task SaveChangesAsync();
    }
}