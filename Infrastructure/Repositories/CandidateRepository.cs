using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Repositories;

public class CandidateRepository(IDbContext dbContext) : ICandidateRepository, IDisposable
{
    private bool disposed;
    
    public async Task AddAsync(Candidate candidate)
    {
        await dbContext.Candidates.AddAsync(candidate);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(Candidate candidate)
    {
        dbContext.Candidates.Update(candidate);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Candidate?> GetByEmail(string email)
    {
        return await dbContext.Candidates.FirstOrDefaultAsync(x => x.Email == email);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}