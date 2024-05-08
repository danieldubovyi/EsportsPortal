using System.Transactions;
using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Matches.Services;
using MediatR;

namespace EsportsPortal.Services.Matches.Commands;
public record UpdateMatchMapsCommand(int MatchId, IReadOnlyCollection<int> MapIds) : IRequest;
internal class UpdateMatchMapsCommandHandler(
    IEntityRepository<MatchMap> matchMapRepository,
    IEntityRepository<Match> matchRepository,
    IMatchResultCalculationService matchResultCalculationService)
    : IRequestHandler<UpdateMatchMapsCommand>
{
    public async Task Handle(UpdateMatchMapsCommand request, CancellationToken cancellationToken)
    {
        var maps = await matchMapRepository.GetListAsync(p => p.MatchId == request.MatchId, cancellationToken);

        var mapsToDelete = maps
            .Where(t => !request.MapIds.Contains(t.MapId))
            .ToArray();
        var mapsToCreate = request.MapIds
            .Except(maps.Select(t => t.MapId))
            .Select(mapId => new MatchMap { MatchId = request.MatchId, MapId = mapId })
            .ToArray();

        using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

        await matchMapRepository.MergeAsync(mapsToCreate, Array.Empty<MatchMap>(), mapsToDelete, cancellationToken);

        maps = await matchMapRepository.GetListAsync(p => p.MatchId == request.MatchId, cancellationToken);
        var mapResults = maps
            .Where(m => m.Result != null)
            .Select(m => m.Result!)
            .ToArray();

        
        var match = await matchRepository.GetAsync(request.MatchId, cancellationToken);
        match.Result = matchResultCalculationService.CalculateMatchResult(mapResults, match.Team1Id, match.Team2Id);
        await matchRepository.UpdateAsync(match, cancellationToken);

        transaction.Complete();
    }
}
