using EsportsPortal.Models.News;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.News.Dto;
using MediatR;

namespace EsportsPortal.Services.News.Queries;
public record GetNewsPostsQuery(int? TopCount) : IRequest<IReadOnlyCollection<NewsPostItem>>;

internal class GetNewsPostsQueryHandler(IEntityRepository<NewsPost> newsPostRepository)
    : IRequestHandler<GetNewsPostsQuery, IReadOnlyCollection<NewsPostItem>>
{
    public async Task<IReadOnlyCollection<NewsPostItem>> Handle(GetNewsPostsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<NewsPostItem> posts = (await newsPostRepository.GetProjectedListAsync(
            p => new NewsPostItem
            {
                Id = p.Id,
                Title = p.Title,
                PublishDate = p.PublishDate,
                ImageFileName = p.ImageFileName
            },
            cancellationToken))
            .OrderByDescending(p => p.PublishDate);

        if (request.TopCount != null)
        {
            posts = posts.Take(request.TopCount.Value);
        }

        return posts.ToArray();
    }
}
