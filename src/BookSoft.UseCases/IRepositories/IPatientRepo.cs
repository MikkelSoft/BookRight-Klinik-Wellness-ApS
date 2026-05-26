using BookSoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.UseCases.IRepositories
{
    public interface IPatientRepo
    {
        Task<Patient> GetByIdAsync(Guid id);
    }
}
