using EsportsPortal.WebApi.Clients;

namespace EsportsPortal.WebUi.Components.Matches;

public class MatchDetailsModel(int tournamentId)
{
    public int? Id { get; set; }
    public int TournamentId => tournamentId;
    public int? Team1Id { get; set; }
    public int? Team2Id { get; set; }
    public DateTime? DateTime { get; set; }
    public MatchFormat? MatchFormat { get; set; }
}
