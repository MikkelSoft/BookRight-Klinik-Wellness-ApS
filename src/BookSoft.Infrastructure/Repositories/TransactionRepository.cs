using System;
using System.Collections.Generic;
using System.Text;
using BookSoft.Domain.Entities;
using BookSoft.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BookSoft.Domain.Enums;
using BookSoft.UseCases.IRepositories;

namespace BookSoft.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepo
{
    private readonly BookSoftDbContext _db;

    public TransactionRepository(BookSoftDbContext db)
    {
        _db = db;
    }
    /*
    // GET all
    public async Task<List<Transaction>> GetAllAsync(CancellationToken ct = default)
    {
        return await _db.Transactions
            .Include(t => t.Patient)
            .ToListAsync(ct);
    }
    */
    // GET by Id
    public async Task<Transaction?> GetByIdAsync(Guid id)
    {
        return await _db.Transactions
            .Include(t => t.Patient)
            .FirstOrDefaultAsync(t => t.ID == id);
    }
    /*
    // GET by patient
    public async Task<List<Transaction>> GetByPatientAsync(Guid patientId, CancellationToken ct = default)
    {
        return await _db.Transactions
            .Where(t => t.PatientId == patientId)
            .OrderByDescending(t => t.TransactionDate)
            .ToListAsync(ct);
    }

    // GET by date range
    public async Task<List<Transaction>> GetByDateRangeAsync(DateTime from, DateTime to, CancellationToken ct = default)
    {
        return await _db.Transactions
            .Where(t => t.TransactionDate >= from && t.TransactionDate <= to)
            .Include(t => t.Patient)
            .OrderByDescending(t => t.TransactionDate)
            .ToListAsync(ct);
    }

    // GET unpaid transactions
    public async Task<List<Transaction>> GetUnpaidAsync(CancellationToken ct = default)
    {
        return await _db.Transactions
            .Where(t => t.Status != TransactionStatus.Completed)
            .Include(t => t.Patient)
            .OrderBy(t => t.TransactionDate)
            .ToListAsync(ct);
    }

    // GET total revenue in a date range
    public async Task<decimal> GetTotalRevenueAsync(DateTime from, DateTime to, CancellationToken ct = default)
    {
        return await _db.Transactions
            .Where(t => t.TransactionDate >= from && t.TransactionDate <= to && t.Status == TransactionStatus.Completed)
            .SumAsync(t => t.cost, ct);
    }

    // GET outstanding balance for a patient
    public async Task<decimal> GetOutstandingBalanceAsync(Guid patientId, CancellationToken ct = default)
    {
        return await _db.Transactions
            .Where(t => t.PatientId == patientId && t.Status != TransactionStatus.Completed)
            .SumAsync(t => t.cost, ct);
    }

    // CREATE
    public async Task AddAsync(Transaction transaction, CancellationToken ct = default)
    {
        await _db.Transactions.AddAsync(transaction, ct);
    }*/

    // UPDATE
    public void Update(Transaction transaction)
    {
        _db.Transactions.Update(transaction);
    }

    // SAVE
    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}