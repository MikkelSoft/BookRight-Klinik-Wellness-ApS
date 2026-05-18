using BookSoft.Facade.DTOs;


namespace BookSoft.Facade.Interfaces
{
    //all methods are in async so that the program doesnt stop while waiting for the database to respond
    public interface IpractitionerService
    {
        // GET: the reading functions for the patient
        Task<List<Practitioner>> GetAllAsync();
        Task<List<Practitioner>> GetByNameAsync(string name);
        Task<List<Practitioner>> GetByIdAsync(int id);

        //create operations for the patient
        Task AddAsync(Practitioner practitioner);

        //update operations for the patient
        Task UpdateAsync(Practitioner practitioner);

        //delete operations for the patient
        Task DeleteAsync(Practitioner practitioner);

        //save changes to the database
        Task SaveChangesAsync();
    }
}
