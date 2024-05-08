using EsportsPortal.Models.Teams;

namespace EsportsPortal.Models.Matches;
public class MatchResult
{
    public int WinnerTeamId { get; set; }

    public Team? WinnerTeam { get; set; }

    public int Team1MapWins { get; set; }

    public int Team2MapWins { get; set; }
}
