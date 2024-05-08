using EsportsPortal.Models.Users;
using EsportsPortal.Services.News.Commands;
using EsportsPortal.Services.News.Dto;
using EsportsPortal.Services.News.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EsportsPortal.WebApi.Controllers;
[Route("api/news")]
[ApiController]
public class NewsController(ISender sender)
    : ControllerBase
{
    [HttpGet("posts")]
    public async Task<IReadOnlyCollection<NewsPostItem>> GetNewsPosts(int? topCount, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetNewsPostsQuery(topCount), cancellationToken);
    }

    [HttpGet("posts/{postId:int}")]
    public async Task<NewsPostDetails> GetNewsPostDetails(int postId, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetNewsPostDetailsQuery(postId), cancellationToken);
    }

    [HttpGet("posts/{postId:int}/tags")]
    public async Task<IReadOnlyCollection<string>> GetNewsPostTags(int postId, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetNewsPostTagsQuery(postId), cancellationToken);
    }

    [HttpGet("posts/tags")]
    public async Task<IReadOnlyCollection<string>> GetAllNewsPostTags(CancellationToken cancellationToken)
    {
        return await sender.Send(new GetNewsPostTagsQuery(null), cancellationToken);
    }

    [HttpPost("posts")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task<int> CreateNewsPost(NewsPostCreateParams newsPostCreateParams, CancellationToken cancellationToken)
    {
        return await sender.Send(new CreateNewsPostCommand(newsPostCreateParams), cancellationToken);
    }

    [HttpPut("posts/{postId:int}")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateNewsPost(int postId, NewsPostCreateParams newsPostUpdateParams, CancellationToken cancellationToken)
    {
        await sender.Send(new UpdateNewsPostCommand(postId, newsPostUpdateParams), cancellationToken);
    }

    [HttpDelete("posts/{postId:int}")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task DeleteNewsPost(int postId, CancellationToken cancellationToken)
    {
        await sender.Send(new DeleteNewsPostCommand(postId), cancellationToken);
    }

    [HttpPut("posts/{postId:int}/image")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateNewsPostImage(int postId, IFormFile file, CancellationToken cancellationToken)
    {
        using var stream = file.OpenReadStream();
        var uploadCommand = new UpdateNewsPostImageCommand(postId, stream, file.FileName);
        await sender.Send(uploadCommand, cancellationToken);
    }

    [HttpPut("posts/{postId:int}/tags")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdateNewsPostTags(int postId, IReadOnlyCollection<string> tags, CancellationToken cancellationToken)
    {
        await sender.Send(new UpdateNewsPostTagsCommand(postId, tags), cancellationToken);
    }
}
