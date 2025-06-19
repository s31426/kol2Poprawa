using codeFirst_Playermatch.Models;
using Microsoft.EntityFrameworkCore;

namespace codeFirst_Playermatch.Data;

public class DatabaseContext : DbContext
{
    
    public DbSet<Match> Matches { get; set; } = null!;
    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Tournament> Tournaments { get; set; } = null!;
    public DbSet<Map> Maps { get; set; } = null!;
    public DbSet<PlayerMatch> PlayerMatches { get; set; } = null!;
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Map>().HasData(new List<Map>()
        {
            new Map() { MapId = 1, Name = "Lewis", Type = "Hamilton" }
        });
        
        modelBuilder.Entity<Match>().HasData(new List<Match>()
        {
            new Match() { MatchId = 1, TournamentId = 1, MapId = 1, MatchDate = DateTime.Parse("2025-07-14"), Team1Score = 1,Team2Score = 1 ,BestRating = 1}

        });
        
        modelBuilder.Entity<Models.Player>().HasData(new List<Models.Player>()
        {
            new Models.Player() { PlayerId = 1, FirstName = "British Grand Prix", LastName = "Silverstone, UK", BirthDate = DateTime.Parse("2025-07-14")}
        });
        
        modelBuilder.Entity<PlayerMatch>().HasData(new List<PlayerMatch>()
        {
            new PlayerMatch() { MatchId = 1, PlayerId = 1, MVPs = 1, Rating = 52.1}
        });
        
        modelBuilder.Entity<Tournament>().HasData(new List<Tournament>()
        {
            new Tournament() { TournamentId = 1, Name = "dwadwad", StartDate =  DateTime.Parse("2025-07-14"), EndDate =  DateTime.Parse("2025-07-14")},
        });
    }
}