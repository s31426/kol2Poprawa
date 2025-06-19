using Kol2Poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kol2Poprawa.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RacersController : ControllerBase
{
    private readonly IDbService _dbService;

    public RacersController(IDbService dbService)
    {
        _dbService = dbService;
    }
}