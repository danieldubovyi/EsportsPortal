using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Files;
using MediatR;

namespace EsportsPortal.Services.Coaches.Commands;
public record UpdateCoachPhotoCommand(int CoachId, Stream File, string FileName) : IRequest;

internal class UpdateCoachPhotoCommandHandler(
    IFileService fileService,
    IEntityRepository<Coach> coachRepository)
    : IRequestHandler<UpdateCoachPhotoCommand>
{
    public async Task Handle(UpdateCoachPhotoCommand request, CancellationToken cancellationToken)
    {
        var coach = await coachRepository.GetAsync(request.CoachId, cancellationToken);
        string fileName = string.Concat($"coach-photo-{DateTime.Now.Ticks.ToString()[12..]}-", request.FileName);
        await fileService.CreateFileAsync(request.File, fileName, cancellationToken);
        coach.PhotoFileName = fileName;
        await coachRepository.UpdateAsync(coach, cancellationToken);
    }
}
