using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public interface IDbContext : IDisposable
{
    public DbSet<Candidate> Candidates { get; set; }
    //public void Dispose();
    Task<int> SaveChangesAsync();
}