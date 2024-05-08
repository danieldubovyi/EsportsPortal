using System.Linq.Expressions;
using EsportsPortal.Models.News;
using EsportsPortal.Models.Repositories;
using MediatR;

namespace EsportsPortal.Services.News.Queries;
public record GetNewsPostTagsQuery(int? NewsPostId) : IRequest<IReadOnlyCollection<string>>;

internal class GetNewsPostTagsQueryHandler(IEntityRepository<NewsPostTag> newsPostTagRepository)
    : IRequestHandler<GetNewsPostTagsQuery, IReadOnlyCollection<string>>
{
    public async Task<IReadOnlyCollection<string>> Handle(GetNewsPostTagsQuery request, CancellationToken cancellationToken)
    {
        var tags = await newsPostTagRepository.GetProjectedListAsync(GetFilter(request), t => t.Name, cancellationToken);
        return tags.Distinct().ToArray();
    }

    private static Expression<Func<NewsPostTag, bool>>? GetFilter(GetNewsPostTagsQuery request)
    {
        if (request.NewsPostId == null)
        {
            return null;
        }

        return t => t.NewsPostId == request.NewsPostId;
    }
}
