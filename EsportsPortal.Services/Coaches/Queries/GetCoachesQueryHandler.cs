using System.Linq.Expressions;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Coaches.Dto;
using MediatR;

namespace EsportsPortal.Services.Coaches.Queries;
public record GetCoachesQuery(bool? NotInTeam) : IRequest<IReadOnlyCollection<CoachListItem>>;

internal class GetCoachesQueryHandler(
    IEntityRepository<Coach> coachRepository)
    : IRequestHandler<GetCoachesQuery, IReadOnlyCollection<CoachListItem>>
{
    public async Task<IReadOnlyCollection<CoachListItem>> Handle(GetCoachesQuery request, CancellationToken cancellationToken)
    {
        var filter = GetFilter(request);

        return await coachRepository.GetProjectedListAsync(filter,
            c => new CoachListItem
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Nickname = c.Nickname,
                PhotoFileName = c.PhotoFileName,
                TeamName = c.Team!.Name,
                TeamLogoFileName = c.Team!.LogoFileName
            }, cancellationToken);
    }

    private static Expression<Func<Coach, bool>>? GetFilter(GetCoachesQuery query)
    {
        List<Expression<Func<Coach, bool>>> expressions = [];

        if (query.NotInTeam.HasValue)
        {
            if (query.NotInTeam.Value)
            {
                expressions.Add(c => c.TeamId == null);
            }
            else
            {
                expressions.Add(c => c.TeamId != null);
            }
        }

        return expressions.ToAndExpression();
    }
}
