using EsportsPortal.Models.News;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.News.Dto;
using MediatR;

namespace EsportsPortal.Services.News.Commands;
public record UpdateNewsPostCommand(int NewsPostId, NewsPostCreateParams UpdateParams) : IRequest;

internal class UpdateNewsPostCommandHandler(IEntityRepository<NewsPost> newsPostRepository)
    : IRequestHandler<UpdateNewsPostCommand>
{
    public async Task Handle(UpdateNewsPostCommand request, CancellationToken cancellationToken)
    {
        var post = await newsPostRepository.GetAsync(request.NewsPostId, cancellationToken);
        post.Title = request.UpdateParams.Title;
        post.Body = request.UpdateParams.Body;
        post.PublishDate = request.UpdateParams.PublishDate;

        await newsPostRepository.UpdateAsync(post, cancellationToken);
    }
}
