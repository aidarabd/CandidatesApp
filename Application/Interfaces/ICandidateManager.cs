using Application.Models;

namespace Application.Interfaces;

public interface ICandidateManager
{
    Task AddEditUser(CandidateDto dto);
}