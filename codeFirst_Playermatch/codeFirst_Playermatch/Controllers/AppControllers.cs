using codeFirst_Playermatch.Services;
using Microsoft.AspNetCore.Mvc;

namespace codeFirst_Playermatch.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IDbService _dbService;

    public PlayersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetPlayer(int id)
    {
        try
        {
            var order = await _dbService.GetPlayer(id);
            return Ok(order);
        }
        catch (Exception e)
        {
            return NotFound();
        }
    }
}