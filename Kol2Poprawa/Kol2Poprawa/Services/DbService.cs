using Kol2Poprawa.Data;
using Kol2Poprawa.DTOs;
using Kol2Poprawa.Exceptions;
using Kol2Poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2Poprawa.Services;

public class DbService :IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<GetDTO.characterDTO> GetInfo(int characterId)
    {
        var record = await _context.Characters
            .Where(c => c.CharacterId == characterId)
            .Select(c => new GetDTO.characterDTO()
            {
                firstName = c.FirstName,
                lastName = c.LastName,
                currentWeight = c.CurrentWeight,
                backpackItems = c.Backpacks.Select(b => new GetDTO.BackpackItemsDTO()
                {
                    itemName = b.Item.Name,
                    itemWeight = b.Item.Weight,
                    amount = b.Amount,
                }).ToList(),
                titles = c.CharacterTitles.Select(t => new GetDTO.TitlesDTO()
                {
                    title = t.Title.Name,
                    aquiredAT = t.AcquiredAt
                }).ToList(),
            }).FirstOrDefaultAsync();
        if (record == null)
        {
            throw new NoCharacter();
        }

        return record;
    }
    

    public async Task UpdateEq(int charId, List<int> Ids)
    {

        var items = new List<Item>();

        foreach (var id in Ids)
        {
            var item = await _context.Items
                .FirstOrDefaultAsync(i => i.itemId == id);

            if (item == null)
            {
                throw new NoItem();
            }

            items.Add(item);
        }

        var character = await _context.Characters
            .Include(b => b.Backpacks)
            .ThenInclude(i => i.Item)
            .Where(c => c.CharacterId == charId)
            .FirstOrDefaultAsync();

        if (character == null)
        {
            throw new Exception();
        }


        var itemsWeight = items.Sum(w => w.Weight);

        if (character.CurrentWeight + itemsWeight > character.MaxWeight)
        {
            throw new TooHeavyException();

        }

        foreach (var item in items)
        {
            var existingBack = await _context.Backpacks
                .Include(i => i.Item)
                .Include(c => c.Character)
                .Where(c => c.CharacterId == character.CharacterId)
                .Where(i => i.Item.itemId == item.itemId)
                .FirstOrDefaultAsync();

            if (existingBack == null)
            {

                var backpack = new Backpack
                {
                    CharacterId = character.CharacterId,
                    ItemId = item.itemId,
                    Amount = 1
                };

                character.Backpacks.Add(backpack);

            }
            else
            {
                existingBack.Amount = existingBack.Amount + 1;
            }
        }

        character.CurrentWeight = character.CurrentWeight + itemsWeight;
        await _context.SaveChangesAsync();
    }
}