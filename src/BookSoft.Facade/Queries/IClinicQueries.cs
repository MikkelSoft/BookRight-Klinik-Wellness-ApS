using BookSoft.Facade.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSoft.Facade.Queries
{
    /// <summary>
    /// Read-only queries for Clinic data.
    /// These are used by pages that only need to display clinics —
    /// they never modify data, so they bypass the use case layer
    /// and go straight to the DB via the query handler.
    /// </summary>
    public interface IClinicQueries
    {
        /// <summary>Returns all clinics. Used for list pages and appointment booking dropdowns.</summary>
        Task<IReadOnlyList<ClinicDto>> GetAllAsync();

        /// <summary>Returns a single clinic by Id, or null if not found.</summary>
        Task<ClinicDto?> GetByIdAsync(Guid id);
    }
}
