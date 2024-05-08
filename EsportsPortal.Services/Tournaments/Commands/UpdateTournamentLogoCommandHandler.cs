using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Files;
using MediatR;

namespace EsportsPortal.Services.Tournaments.Commands;
public record UpdateTournamentLogoCommand(int TournamentId, Stream File, string FileName) : IRequest;

internal class UpdateTournamentLogoCommandHandler(
    IFileService fileService,
    IEntityRepository<Tournament> tournamentRepository)
    : IRequestHandler<UpdateTournamentLogoCommand>
{
    public async Task Handle(UpdateTournamentLogoCommand request, CancellationToken cancellationToken)
{
    var tournament = await tournamentRepository.GetAsync(request.TournamentId, cancellationToken);
    string fileName = string.Concat($"tournament-logo-{DateTime.Now.Ticks.ToString()[12..]}-", request.FileName);
    await fileService.CreateFileAsync(request.File, fileName, cancellationToken);
    tournament.LogoFileName = fileName;
    await tournamentRepository.UpdateAsync(tournament, cancellationToken);
}
}
