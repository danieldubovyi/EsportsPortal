using System.Transactions;
using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Matches.Dto;
using EsportsPortal.Services.Matches.Services;
using MediatR;

namespace EsportsPortal.Services.Matches.Commands;
public record UpdateMatchResultsCommand(int MatchId, IReadOnlyCollection<MapResultParams> Results) : IRequest;

internal class UpdateMatchResultsCommandHandler(
    IEntityRepository<MatchMap> matchMapRepository,
    IEntityRepository<Match> matchRepository,
    IMatchResultCalculationService matchResultCalculationService)
    : IRequestHandler<UpdateMatchResultsCommand>
{
    public async Task Handle(UpdateMatchResultsCommand request, CancellationToken cancellationToken)
    {
        var match = await matchRepository.GetAsync(request.MatchId, cancellationToken);
        var maps = await matchMapRepository.GetListAsync(m => m.MatchId == request.MatchId, cancellationToken);

        foreach (var map in maps)
        {
            var result = request.Results.FirstOrDefault(m => m.MapId == map.MapId);
            if (result != null && (result.Team1RoundWins.HasValue || result.Team2RoundWins.HasValue))
            {
                map.Result = new()
                {
                    Team1RoundWins = result.Team1RoundWins ?? 0,
                    Team2RoundWins = result.Team2RoundWins ?? 0,
                    WinnerTeamId = result.Team1RoundWins > result.Team2RoundWins ? match.Team1Id : match.Team2Id
                };
            }
            else
            {
                map.Result = null;
            }
        }

        var mapResults = maps
            .Where(m => m.Result != null)
            .Select(m => m.Result!)
            .ToArray();
        
        match.Result = matchResultCalculationService.CalculateMatchResult(mapResults, match.Team1Id, match.Team2Id);

        using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        await matchMapRepository.UpdateAsync(maps, cancellationToken);
        await matchRepository.UpdateAsync(match, cancellationToken);

        transaction.Complete();
    }
}
