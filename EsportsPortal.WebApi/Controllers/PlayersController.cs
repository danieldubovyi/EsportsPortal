using EsportsPortal.Models.Users;
using EsportsPortal.Services.Players.Commands;
using EsportsPortal.Services.Players.Dto;
using EsportsPortal.Services.Players.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EsportsPortal.WebApi.Controllers;
[ApiController]
[Route("api/players")]
public class PlayersController(ISender sender)
    : ControllerBase
{
    [HttpGet]
    public async Task<IReadOnlyCollection<PlayerListItem>> GetPlayers([FromQuery]bool? notInTeam, CancellationToken cancellationToken)
    {
        var query = new GetPlayersQuery(notInTeam);
        return await sender.Send(query, cancellationToken);
    }

    [HttpGet("{playerId:int}")]
    public async Task<PlayerDetails> GetPlayerDetails(int playerId, CancellationToken cancellationToken)
    {
        var query = new GetPlayerDetailsQuery(playerId);
        return await sender.Send(query, cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = UserRole.Admin)]
    public async Task<int> CreatePlayer(PlayerCreateParams playerCreateParams, CancellationToken cancellationToken)
    {
        return await sender.Send(new CreatePlayerCommand(playerCreateParams), cancellationToken);
    }

    [HttpPut("{playerId:int}")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdatePlayer(int playerId, PlayerCreateParams playerUpdateParams, CancellationToken cancellationToken)
    {
        await sender.Send(new UpdatePlayerCommand(playerId, playerUpdateParams), cancellationToken);
    }

    [HttpDelete("{playerId:int}")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task DeletePlayer(int playerId, CancellationToken cancellationToken)
    {
        await sender.Send(new DeletePlayerCommand(playerId), cancellationToken);
    }

    [HttpPut("{playerId:int}/photo")]
    [Authorize(Roles = UserRole.Admin)]
    public async Task UpdatePlayerPhotoAsync(int playerId, IFormFile file, CancellationToken cancellationToken)
    {
        using var stream = file.OpenReadStream();
        var uploadCommand = new UpdatePlayerPhotoCommand(playerId, stream, file.FileName);
        await sender.Send(uploadCommand, cancellationToken);
    }
}
