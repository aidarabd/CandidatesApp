using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;


namespace Application;

public class CandidateManager(ICandidateRepository candidateRepository, IMapper mapper): ICandidateManager
{

    public async Task AddEditUser(CandidateDto dto)
    {
        //      We could cache newly added candidates with thei e-mail as a key for specific time. Reason for that may be 
        // most of the time users update newly added form. 
        
        //      So before asking database it would be great if we could fetch the data from memory. Redis would be great as separate service
        
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