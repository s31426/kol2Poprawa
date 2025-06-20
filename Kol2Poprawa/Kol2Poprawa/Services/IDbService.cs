using Kol2Poprawa.DTOs;

namespace Kol2Poprawa.Services;

public interface IDbService
{
    
    public Task<GetDTO.characterDTO> GetInfo(int characterId);
    
    public Task UpdateEq(int charId, List<int> ids );
   
}