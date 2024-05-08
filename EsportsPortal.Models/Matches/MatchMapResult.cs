using EsportsPortal.Models.Teams;

namespace EsportsPortal.Models.Matches;
public class MatchMapResult
{
    public int WinnerTeamId { get; set; }

    public Team? WinnerTeam { get; set; }

    public int Team1RoundWins { get; set; }

    public int Team2RoundWins { get; set; }
}
