using Domain.Entities;

namespace Application.Interfaces;

public interface ICandidateRepository
{
    Task AddAsync(Candidate candidate);
    Task UpdateAsync(Candidate candidate);
    Task<Candidate?> GetByEmail(string email);
}