using BookSoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.UseCases.IRepositories
{
    public interface IClinicRepo
    {
        // --- Queries ---
        Task<Clinic?> GetByIdAsync(Guid id);

        /// <summary>Returns all clinics. Used by the Clinic list page and AddClinic dropdowns.</summary>
        Task<List<Clinic>> GetAllAsync();

        // --- Commands ---

        /// <summary>Stages a new Clinic entity for insertion. Call SaveAsync to persist.</summary>
        Task AddAsync(Clinic clinic);

        /// <summary>Marks a Clinic as modified so EF tracks the changes. Call SaveAsync to persist.</summary>
        void Update(Clinic clinic);

        /// <summary>Removes the clinic from the database. Call SaveAsync to persist.</summary>
        Task DeleteAsync(Guid id);

        /// <summary>Flushes all pending changes to the database.</summary>
        Task SaveAsync();
    }
}
