using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Matches.Dto;
using MediatR;

namespace EsportsPortal.Services.Matches.Commands;
public record CreateMatchCommand(MatchCreateParams CreateParams) : IRequest<int>;

internal class CreateMatchCommandHandler(IEntityRepository<Match> matchRepository)
    : IRequestHandler<CreateMatchCommand, int>
{
    public async Task<int> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
    {
        var match = new Match
        {
            TournamentId = request.CreateParams.TournamentId,
            Team1Id = request.CreateParams.Team1Id,
            Team2Id = request.CreateParams.Team2Id,
            DateTime = request.CreateParams.DateTime,
            MatchFormat = request.CreateParams.MatchFormat
        };

        await matchRepository.CreateAsync(match, cancellationToken);

        return match.Id;
    }
}
