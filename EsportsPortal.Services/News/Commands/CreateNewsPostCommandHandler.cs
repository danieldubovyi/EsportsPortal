using EsportsPortal.Models.News;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.News.Dto;
using MediatR;

namespace EsportsPortal.Services.News.Commands;
public record CreateNewsPostCommand(NewsPostCreateParams CreateParams) : IRequest<int>;

internal class CreateNewsPostCommandHandler(IEntityRepository<NewsPost> newsPostRepository)
    : IRequestHandler<CreateNewsPostCommand, int>
{
    public async Task<int> Handle(CreateNewsPostCommand request, CancellationToken cancellationToken)
    {
        var post = new NewsPost
        {
            Title = request.CreateParams.Title,
            Body = request.CreateParams.Body,
            PublishDate = request.CreateParams.PublishDate
        };

        await newsPostRepository.CreateAsync(post, cancellationToken);

        return post.Id;
    }
}
