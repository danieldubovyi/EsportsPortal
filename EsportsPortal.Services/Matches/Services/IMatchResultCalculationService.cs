using EsportsPortal.Models.Matches;

namespace EsportsPortal.Services.Matches.Services;
public interface IMatchResultCalculationService
{
    MatchResult? CalculateMatchResult(IReadOnlyCollection<MatchMapResult> mapResults, int team1Id, int team2Id);
}
