using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Tournaments.Dto;
using MediatR;

namespace EsportsPortal.Services.Tournaments.Commands;
public record UpdateTournamentCommand(int TournamentId, TournamentCreateParams UpdateParams) : IRequest;

internal class UpdateTournamentCommandHandler(IEntityRepository<Tournament> tournamentRepository)
    : IRequestHandler<UpdateTournamentCommand>
{
    public async Task Handle(UpdateTournamentCommand request, CancellationToken cancellationToken)
    {
        var tournament = await tournamentRepository.GetAsync(request.TournamentId, cancellationToken);
        tournament.Name = request.UpdateParams.Name;
        tournament.StartDate = request.UpdateParams.StartDate;
        tournament.EndDate = request.UpdateParams.EndDate;
        tournament.LocationId = request.UpdateParams.LocationId;
        tournament.PrizePool = request.UpdateParams.PrizePool;

        await tournamentRepository.UpdateAsync(tournament, cancellationToken);
    }
}
