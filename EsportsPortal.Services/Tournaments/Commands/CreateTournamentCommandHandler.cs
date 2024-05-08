using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Tournaments.Dto;
using MediatR;

namespace EsportsPortal.Services.Tournaments.Commands;
public record CreateTournamentCommand(TournamentCreateParams CreateParams) : IRequest<int>;

internal class CreateTournamentCommandHandler(IEntityRepository<Tournament> tournamentRepository)
    : IRequestHandler<CreateTournamentCommand, int>
{
    public async Task<int> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
    {
        var tournament = new Tournament
        {
            Name = request.CreateParams.Name,
            StartDate = request.CreateParams.StartDate,
            EndDate = request.CreateParams.EndDate,
            LocationId = request.CreateParams.LocationId,
            PrizePool = request.CreateParams.PrizePool
        };

        await tournamentRepository.CreateAsync(tournament, cancellationToken);

        return tournament.Id;
    }
}
