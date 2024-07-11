using WebApplication1.Application.Models;

namespace WebApplication1.Application.Interfaces;

public interface ICandidateManager
{
    Task AddEditUser(CandidateDto dto);
}