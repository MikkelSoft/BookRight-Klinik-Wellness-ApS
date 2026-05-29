using BookSoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.UseCases.IRepositories
{
    public interface IPatientRepo
    {
        // Task<Patient> GetByIdAsync(Guid id); // remove the ? to make it non-nullable
        Task<List<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(Guid id);
        Task<List<Patient>> GetByNameAsync(string name);
        Task AddAsync(Patient patient);
        void Update(Patient patient);
        Task SaveAsync();
        Task DeleteAsync(Guid id);

    }
}
