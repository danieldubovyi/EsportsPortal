using EsportsPortal.Models.News;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Files;
using MediatR;

namespace EsportsPortal.Services.News.Commands;
public record UpdateNewsPostImageCommand(int NewsPostId, Stream File, string FileName) : IRequest;
internal class UpdateNewsPostImageCommandHandler(
    IFileService fileService,
    IEntityRepository<NewsPost> newsPostRepository)
    : IRequestHandler<UpdateNewsPostImageCommand>
{
    public async Task Handle(UpdateNewsPostImageCommand request, CancellationToken cancellationToken)
    {
        var newsPost = await newsPostRepository.GetAsync(request.NewsPostId, cancellationToken);
        string fileName = string.Concat($"news-image-{DateTime.Now.Ticks.ToString()[12..]}-", request.FileName);
        await fileService.CreateFileAsync(request.File, fileName, cancellationToken);
        newsPost.ImageFileName = fileName;
        await newsPostRepository.UpdateAsync(newsPost, cancellationToken);
    }
}
