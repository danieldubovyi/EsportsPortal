using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using MediatR;

namespace EsportsPortal.Services.Matches.Commands;
public record DeleteMatchCommand(int MatchId) : IRequest;

internal class DeleteMatchCommandHandler(IEntityRepository<Match> matchRepository)
    : IRequestHandler<DeleteMatchCommand>
{
    public async Task Handle(DeleteMatchCommand request, CancellationToken cancellationToken)
    {
        await matchRepository.DeleteAsync(request.MatchId, cancellationToken);
    }
}
