using BookSoft.Facade.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Facade.Queries
{
    public interface IPractitionerQueries
    {
        Task<IReadOnlyList<PractitionerDto>> GetAllAsync();
        Task<PractitionerDto?> GetByIdAsync(Guid Id);
    }
}
