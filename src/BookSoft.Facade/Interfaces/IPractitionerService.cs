using BookSoft.Facade.DTOs;


namespace BookSoft.Facade.Interfaces
{
    //all methods are in async so that the program doesnt stop while waiting for the database to respond
    public interface IPractitionerService
    {
        // GET: the reading functions for the patient
        Task<List<PractitionerDto>> GetAllAsync();
        Task<List<PractitionerDto>> GetByNameAsync(string name);
        Task<List<PractitionerDto>> GetByIdAsync(int id);

        //create operations for the patient
        Task AddAsync(PractitionerDto practitioner);

        //update operations for the patient
        Task UpdateAsync(PractitionerDto practitioner);

        //delete operations for the patient
        Task DeleteAsync(PractitionerDto practitioner);

        //save changes to the database
        Task SaveChangesAsync();
    }
}
