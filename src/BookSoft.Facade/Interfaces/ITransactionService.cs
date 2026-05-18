using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Facade.DTOs;


namespace BookSoft.Facade.Interfaces
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetAllAsync();
        Task<List<Transaction>> GetByPatientIdAsync(int patientId)
    }
}
