using EsportsPortal.Models.News;
using EsportsPortal.Models.Repositories;
using MediatR;

namespace EsportsPortal.Services.News.Commands;
public record UpdateNewsPostTagsCommand(int NewsPostId, IReadOnlyCollection<string> Tags) : IRequest;

internal class UpdateNewsPostTagsCommandHandler(IEntityRepository<NewsPostTag> newsPostTagRepository)
    : IRequestHandler<UpdateNewsPostTagsCommand>
{
    public async Task Handle(UpdateNewsPostTagsCommand request, CancellationToken cancellationToken)
    {
        var existTags = await newsPostTagRepository.GetListAsync(t => t.NewsPostId == request.NewsPostId, cancellationToken);
        var newTags = request.Tags.Distinct().ToArray();

        var tagsToDelete = existTags.Where(t => !newTags.Contains(t.Name)).ToArray();
        var existTagNames = existTags.Select(t => t.Name).ToArray();
        var tagsToCreate = newTags
            .Where(t => !existTagNames.Contains(t))
            .Select(t => new NewsPostTag { NewsPostId = request.NewsPostId, Name = t })
            .ToArray();

        await newsPostTagRepository.MergeAsync(tagsToCreate, Array.Empty<NewsPostTag>(), tagsToDelete, cancellationToken);
    }
}
