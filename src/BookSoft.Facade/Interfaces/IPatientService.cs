using BookSoft.Facade.DTOs;


namespace BookSoft.Facade.Interfaces
{
    //all methods are in async so that the program doesnt stop while waiting for the database to respond
    public interface IPatientService
    {
        // GET: the reading functions for the patient
        Task<List<PatientDto>> GetAllAsync();  
        Task<List<PatientDto>> GetByNameAsync(string name);
        Task<List<PatientDto>> GetByIdAsync(int id);

        //create operations for the patient
        Task AddAsync(PatientDto patient);

        //update operations for the patient
        Task UpdateAsync(PatientDto patient);

        //delete operations for the patient
        Task DeleteAsync(PatientDto patient);

        //save changes to the database
        Task SaveChangesAsync();
    }
}
