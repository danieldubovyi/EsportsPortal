using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Players.Dto;
using MediatR;

namespace EsportsPortal.Services.Players.Queries;
public record GetPlayerDetailsQuery(int PlayerId) : IRequest<PlayerDetails>;

internal class GetPlayerDetailsQueryHandler(IEntityRepository<Player> playerRepository)
    : IRequestHandler<GetPlayerDetailsQuery, PlayerDetails>
{
    public async Task<PlayerDetails> Handle(GetPlayerDetailsQuery request, CancellationToken cancellationToken)
    {
        return await playerRepository.GetAsync(request.PlayerId,
            p => new PlayerDetails
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Nickname = p.Nickname,
                PhotoFileName = p.PhotoFileName,
                DateOfBirth = p.DateOfBirth,
                Rating = p.Rating,
                Role = p.Role,
                TeamId = p.TeamId,
                TeamName = p.Team!.Name,
                TeamLogoFileName = p.Team!.LogoFileName,
                CountryId = p.CountryId,
                CountryName = p.Country!.Name,
                CountryFlagFileName = p.Country.FlagFileName
            }, cancellationToken);
    }
}
