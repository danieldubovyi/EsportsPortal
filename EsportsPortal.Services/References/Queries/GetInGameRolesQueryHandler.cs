using EsportsPortal.Models.Teams;
using EsportsPortal.Services.References.Dto;
using MediatR;

namespace EsportsPortal.Services.References.Queries;
public record GetInGameRolesQuery() : IRequest<IReadOnlyCollection<InGameRoleListItem>>;

internal class GetInGameRolesQueryHandler
    : IRequestHandler<GetInGameRolesQuery, IReadOnlyCollection<InGameRoleListItem>>
{
    public Task<IReadOnlyCollection<InGameRoleListItem>> Handle(GetInGameRolesQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<InGameRoleListItem> items =
            Enum.GetValues<InGameRole>()
            .Select(r => new InGameRoleListItem(r, r.GetDescription()))
            .ToList();

        return Task.FromResult(items);
    }
}
