using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookSoft.Infrastructure.Data;

/// <summary>
/// Used only by EF Core CLI tools (dotnet ef migrations / database update).
/// Not used at runtime — the DI container handles context creation there.
/// </summary>
public class BookSoftDbContextFactory : IDesignTimeDbContextFactory<BookSoftDbContext>
{
    public BookSoftDbContext CreateDbContext(string[] args)
    {
        var opts = new DbContextOptionsBuilder<BookSoftDbContext>();
        opts.UseSqlServer(
            "Server=(localdb)\\mssqllocaldb;Database=BookSoftDB;Trusted_Connection=True;TrustServerCertificate=True");

        return new BookSoftDbContext(opts.Options);
    }
}
