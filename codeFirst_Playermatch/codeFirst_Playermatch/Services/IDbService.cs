using codeFirst_Playermatch.DTOs;

namespace codeFirst_Playermatch.Services;

public interface IDbService
{
    Task<GetDto.PlayerDto> GetPlayer(int id);
}