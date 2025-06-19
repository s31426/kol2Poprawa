using codeFirst_Playermatch.Data;
using codeFirst_Playermatch.DTOs;
using Microsoft.EntityFrameworkCore;

namespace codeFirst_Playermatch.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<GetDto.PlayerDto> GetPlayer(int id)
    {
        var record = await _context.Players
            .Where(r => r.PlayerId == id)
            .Select(r => new GetDto.PlayerDto()
            {
                PlayerId = r.PlayerId,
                FirstName = r.FirstName,
                LastName = r.LastName,
                BirthDate = r.BirthDate,
                Matches = r.PlayerMatches.Select(pm => new GetDto.MatchInfoDto()
                {
                    TournamentName = pm.Match.Tournament.Name,
                    MapName = pm.Match.Map.Name,
                    Date = pm.Match.MatchDate,
                    Team1Score = pm.Match.Team1Score,
                    Team2Score = pm.Match.Team2Score,
                }).ToList()
            }).FirstOrDefaultAsync();
        if (record == null)
            throw new NullReferenceException();
        return record;
    }
}