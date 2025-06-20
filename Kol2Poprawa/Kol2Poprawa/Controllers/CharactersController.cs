using Kol2Poprawa.DTOs;
using Kol2Poprawa.Exceptions;
using Kol2Poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kol2Poprawa.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;

    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet("/api/characters/{id}")]
    public async Task<IActionResult> GetCharacter(int id)
    {
        try
        {
            var result = await _dbService.GetInfo(id);
            return Ok(result);
        }
        catch (NoCharacter e)
        {
            return BadRequest("No character found");
        }
        catch (Exception e)
        {
            return BadRequest("Smth wrong");
        }

    }
    
    
    [HttpPost("/api/characters/{id}/backpacks")]
    public async Task<IActionResult> InsertItems(int id, PostDTO dto)
    {

        try
        {
            await _dbService.UpdateEq(id, dto.ids);
            return Ok();
        }
        catch (TooHeavyException e)
        {
            return Conflict("Too heavy");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
}