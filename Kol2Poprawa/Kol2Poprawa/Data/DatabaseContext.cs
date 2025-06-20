using Kol2Poprawa.Models;
using Microsoft.EntityFrameworkCore;
namespace Kol2Poprawa.Data;

public class DatabaseContext : DbContext
{
    
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>()
        {
            new Backpack() {CharacterId = 1, ItemId = 1, Amount = 1}
      
        });
    
        modelBuilder.Entity<Character>().HasData(new List<Character>()
        {
            new Character() { CharacterId = 1, FirstName = "1", LastName = "1", CurrentWeight = 2, MaxWeight = 3 }
        });
    
        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>()
        {
            new CharacterTitle() { CharacterId = 1, TitleId = 1, AcquiredAt = new DateTime(2024, 1, 1) }
        });
    
        modelBuilder.Entity<Item>().HasData(new List<Item>()
        {
            new Item() { itemId = 1, Name = "1", Weight = 1 }
       
        });
    
        modelBuilder.Entity<Title>().HasData(new List<Title>()
        {
            new Title() { TitleId = 1, Name = "3" }
        });
    }
}