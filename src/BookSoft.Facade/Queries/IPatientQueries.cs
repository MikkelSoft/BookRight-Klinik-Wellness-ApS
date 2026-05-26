using BookSoft.Facade.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.Facade.Queries
{
    public interface IPatientQueries
    {
        Task<IReadOnlyList<PatientDto>> GetAllAsync();
        Task<PatientDto> GetByIdAsync(Guid Id);
    }
}
