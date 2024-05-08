using EsportsPortal.Models.News;
using EsportsPortal.Models.Repositories;
using MediatR;

namespace EsportsPortal.Services.News.Commands;
public record DeleteNewsPostCommand(int NewsPostId) : IRequest;

internal class DeleteNewsPostCommandHandler(IEntityRepository<NewsPost> newsPostRepository)
    : IRequestHandler<DeleteNewsPostCommand>
{
    public async Task Handle(DeleteNewsPostCommand request, CancellationToken cancellationToken)
    {
        await newsPostRepository.DeleteAsync(request.NewsPostId, cancellationToken);
    }
}
