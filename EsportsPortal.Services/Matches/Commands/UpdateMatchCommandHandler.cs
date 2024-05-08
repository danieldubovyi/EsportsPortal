using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Matches.Dto;
using MediatR;

namespace EsportsPortal.Services.Matches.Commands;
public record UpdateMatchCommand(int MatchId, MatchCreateParams UpdateParams) : IRequest;

internal class UpdateMatchCommandHandler(IEntityRepository<Match> matchRepository)
    : IRequestHandler<UpdateMatchCommand>
{
    public async Task Handle(UpdateMatchCommand request, CancellationToken cancellationToken)
    {
        var match = await matchRepository.GetAsync(request.MatchId, cancellationToken);
        match.TournamentId = request.UpdateParams.TournamentId;
        match.Team1Id = request.UpdateParams.Team1Id;
        match.Team2Id = request.UpdateParams.Team2Id;
        match.DateTime = request.UpdateParams.DateTime;
        match.MatchFormat = request.UpdateParams.MatchFormat;

        await matchRepository.UpdateAsync(match, cancellationToken);
    }
}
