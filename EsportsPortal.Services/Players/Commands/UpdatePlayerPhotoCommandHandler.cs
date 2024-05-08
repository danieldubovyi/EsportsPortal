using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Files;
using MediatR;

namespace EsportsPortal.Services.Players.Commands;
public record UpdatePlayerPhotoCommand(int PlayerId, Stream File, string FileName) : IRequest;

internal class UpdatePlayerPhotoCommandHandler(
    IFileService fileService,
    IEntityRepository<Player> playerRepository)
    : IRequestHandler<UpdatePlayerPhotoCommand>
{
    public async Task Handle(UpdatePlayerPhotoCommand request, CancellationToken cancellationToken)
    {
        var player = await playerRepository.GetAsync(request.PlayerId, cancellationToken);
        string fileName = string.Concat($"player-photo-{DateTime.Now.Ticks.ToString()[12..]}-", request.FileName);
        await fileService.CreateFileAsync(request.File, fileName, cancellationToken);
        player.PhotoFileName = fileName;
        await playerRepository.UpdateAsync(player, cancellationToken);
    }
}
