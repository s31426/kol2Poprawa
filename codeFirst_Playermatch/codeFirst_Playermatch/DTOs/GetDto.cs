namespace codeFirst_Playermatch.DTOs;

public class GetDto
{
    public class PlayerDto
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<MatchInfoDto> Matches { get; set; }
    }

    public class MatchInfoDto
    {
        public string TournamentName {get; set;}
        public string MapName {get; set;}
        public DateTime Date {get; set;}
        public int MVPs {get; set;}
        public double rating {get; set;}
        public int Team1Score {get; set;}
        public int Team2Score {get; set;}
    }
}