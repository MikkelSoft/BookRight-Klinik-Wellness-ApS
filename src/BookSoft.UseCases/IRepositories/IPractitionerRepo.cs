// BookSoft.UseCases/IRepositories/IPractitionerRepo.cs

using BookSoft.Domain.Entities;

namespace BookSoft.UseCases.IRepositories
{
    public interface IPractitionerRepo
    {
        Task<List<Practitioner>> GetAllAsync(CancellationToken ct = default);
        Task<Practitioner?> GetByIdAsync(Guid id);
        Task<List<Practitioner>> GetBySpecialtyAsync(string specialty, CancellationToken ct = default);
        Task AddAsync(Practitioner practitioner, CancellationToken ct = default);
        void Update(Practitioner practitioner);
        Task SaveAsync(CancellationToken ct = default);
        Task Delete(Practitioner practitioner);
    }
}