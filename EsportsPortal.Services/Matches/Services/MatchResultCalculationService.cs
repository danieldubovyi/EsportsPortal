using EsportsPortal.Models.Matches;

namespace EsportsPortal.Services.Matches.Services;
internal class MatchResultCalculationService : IMatchResultCalculationService
{
    public MatchResult? CalculateMatchResult(IReadOnlyCollection<MatchMapResult> mapResults, int team1Id, int team2Id)
    {
        if (mapResults.Count > 0)
        {
            var team1MapWins = mapResults.Count(r => r.WinnerTeamId == team1Id);
            var team2MapWins = mapResults.Count(r => r.WinnerTeamId == team2Id);
            return new()
            {
                Team1MapWins = team1MapWins,
                Team2MapWins = team2MapWins,
                WinnerTeamId = team1MapWins > team2MapWins ? team1Id : team2Id
            };
        }
        
        return null;
    }
}
