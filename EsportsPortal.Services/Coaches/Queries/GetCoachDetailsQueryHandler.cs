using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Coaches.Dto;
using MediatR;

namespace EsportsPortal.Services.Coaches.Queries;
public record GetCoachDetailsQuery(int CoachId) : IRequest<CoachDetails>;

internal class GetCoachDetailsQueryHandler(IEntityRepository<Coach> coachRepository)
    : IRequestHandler<GetCoachDetailsQuery, CoachDetails>
{
    public async Task<CoachDetails> Handle(GetCoachDetailsQuery request, CancellationToken cancellationToken)
    {
        return await coachRepository.GetAsync(request.CoachId,
            c => new CoachDetails
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Nickname = c.Nickname,
                PhotoFileName = c.PhotoFileName,
                DateOfBirth = c.DateOfBirth,
                TeamId = c.TeamId,
                TeamName = c.Team!.Name,
                TeamLogoFileName = c.Team!.LogoFileName,
                CountryId = c.CountryId,
                CountryName = c.Country!.Name,
                CountryFlagFileName = c.Country.FlagFileName
            }, cancellationToken);
    }
}
