using BookSoft.Facade.DTOs;


namespace BookSoft.Facade.Interfaces
{
    //all methods are in async so that the program doesnt stop while waiting for the database to respond
    public interface IPatientService
    {
        // GET: the reading functions for the patient
        Task<List<Patient>> GetAllAsync();  
        Task<List<Patient>> GetByNameAsync(string name);
        Task<List<Patient>> GetByIdAsync(int id);

        //create operations for the patient
        Task AddAsync(Patient patient);

        //update operations for the patient
        Task UpdateAsync(Patient patient);

        //delete operations for the patient
        Task DeleteAsync(Patient patient);

        //save changes to the database
        Task SaveChangesAsync();
    }
}
