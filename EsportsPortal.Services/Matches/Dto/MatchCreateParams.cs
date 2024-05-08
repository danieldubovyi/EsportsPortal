using EsportsPortal.Models.Matches;

namespace EsportsPortal.Services.Matches.Dto;
public class MatchCreateParams
{
    public int TournamentId { get; set; }
    public int Team1Id { get; set; }
    public int Team2Id { get; set;}
    public DateTime DateTime { get; set; }
    public MatchFormat MatchFormat { get; set; }
}
