using BookSoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSoft.UseCases.IRepositories
{
    public interface IClinicRepo
    {
        Task<Clinic?> GetByIdAsync(Guid id);
    }
}
