using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;


namespace Application;

public class CandidateManager(ICandidateRepository candidateRepository, IMapper mapper): ICandidateManager
{

    public async Task AddEditUser(CandidateDto dto)
    {
        var candidate = await candidateRepository.GetByEmail(dto.Email);

        if (candidate == null)
        {
            await AddCandidateAsync(dto);
        }
        else
        {
            await UpdateCandidateAsync(dto, candidate);
        }
    }

    private async Task AddCandidateAsync(CandidateDto dto)
    {
        var candidate = mapper.Map<Candidate>(dto);
        await candidateRepository.AddAsync(candidate);
    }

    private async Task UpdateCandidateAsync(CandidateDto dto, Candidate existingCandidate)
    {
        mapper.Map(dto, existingCandidate);
        await candidateRepository.UpdateAsync(existingCandidate);
    }
    
}