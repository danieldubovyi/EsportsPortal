using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using MediatR;

namespace EsportsPortal.Services.Tournaments.Commands;
public record DeleteTournamentCommand(int TournamentId) : IRequest;

internal class DeleteTournamentCommandHandler(IEntityRepository<Tournament> tournamentRepository)
    : IRequestHandler<DeleteTournamentCommand>
{
    public async Task Handle(DeleteTournamentCommand request, CancellationToken cancellationToken)
    {
        await tournamentRepository.DeleteAsync(request.TournamentId, cancellationToken);
    }
}
