using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class CandidateController(ICandidateManager manager) : ControllerBase
{
    [HttpPost(Name = "add-edit-candidate")]
    public async Task<ActionResult> AddEdit(CandidateDto dto)
    {
        await manager.AddEditUser(dto);
        return Ok();
    }
}