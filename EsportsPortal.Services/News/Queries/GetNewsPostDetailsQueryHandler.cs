using EsportsPortal.Models.News;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.News.Dto;
using MediatR;

namespace EsportsPortal.Services.News.Queries;
public record GetNewsPostDetailsQuery(int NewsPostId) : IRequest<NewsPostDetails>;

internal class GetNewsPostDetailsQueryHandler(IEntityRepository<NewsPost> newsPostRepository)
    : IRequestHandler<GetNewsPostDetailsQuery, NewsPostDetails>
{
    public async Task<NewsPostDetails> Handle(GetNewsPostDetailsQuery request, CancellationToken cancellationToken)
    {
        return await newsPostRepository.GetAsync(
            request.NewsPostId,
            p => new NewsPostDetails
            {
                Id = p.Id,
                Title = p.Title,
                PublishDate = p.PublishDate,
                ImageFileName = p.ImageFileName,
                Body = p.Body
            },
            cancellationToken);
    }
}
