using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Files;
using MediatR;

namespace EsportsPortal.Services.Teams.Commands;
public record UpdateTeamLogoCommand(int TeamId, Stream File, string FileName) : IRequest;

internal class UpdateTeamLogoCommandHandler(
    IFileService fileService,
    IEntityRepository<Team> teamRepository)
    : IRequestHandler<UpdateTeamLogoCommand>
{
    public async Task Handle(UpdateTeamLogoCommand request, CancellationToken cancellationToken)
    {
        var team = await teamRepository.GetAsync(request.TeamId, cancellationToken);
        string fileName = string.Concat($"team-logo-{DateTime.Now.Ticks.ToString()[12..]}-", request.FileName);
        await fileService.CreateFileAsync(request.File, fileName, cancellationToken);
        team.LogoFileName = fileName;
        await teamRepository.UpdateAsync(team, cancellationToken);
    }
}
