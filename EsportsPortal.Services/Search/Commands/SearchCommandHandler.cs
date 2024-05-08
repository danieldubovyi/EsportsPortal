using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using EsportsPortal.Services.Search.Dto;
using MediatR;

namespace EsportsPortal.Services.Search.Commands;
public record SearchCommand(string SearchTerm) : IRequest<IReadOnlyCollection<SearchResult>>;

internal class SearchCommandHandler(
    IEntityRepository<Team> teamRepository,
    IEntityRepository<Player> playerRepository,
    IEntityRepository<Coach> coachRepository,
    IEntityRepository<Tournament> tournamentRepository)
    : IRequestHandler<SearchCommand, IReadOnlyCollection<SearchResult>>
{
    public async Task<IReadOnlyCollection<SearchResult>> Handle(SearchCommand request, CancellationToken cancellationToken)
    {
        var teams = await teamRepository.GetProjectedListAsync(t => t.Name.Contains(request.SearchTerm),
            t => new SearchResult
            {
                Type = SearchResultType.Team,
                Id = t.Id,
                Name = t.Name,
                ImageFileName = t.LogoFileName
            }, cancellationToken);

        var players = await playerRepository.GetProjectedListAsync(
            t => t.FirstName.Contains(request.SearchTerm) || t.LastName.Contains(request.SearchTerm) || t.Nickname.Contains(request.SearchTerm),
            t => new SearchResult
            {
                Type = SearchResultType.Player,
                Id = t.Id,
                Name = $"{t.FirstName} '{t.Nickname}' {t.LastName}",
                ImageFileName = t.PhotoFileName
            }, cancellationToken);

        var coaches = await coachRepository.GetProjectedListAsync(
            t => t.FirstName.Contains(request.SearchTerm) || t.LastName.Contains(request.SearchTerm) || t.Nickname.Contains(request.SearchTerm),
            t => new SearchResult
            {
                Type = SearchResultType.Coach,
                Id = t.Id,
                Name = $"{t.FirstName} '{t.Nickname}' {t.LastName}",
                ImageFileName = t.PhotoFileName
            }, cancellationToken);

        var tournaments = await tournamentRepository.GetProjectedListAsync(t => t.Name.Contains(request.SearchTerm),
            t => new SearchResult
            {
                Type = SearchResultType.Tournament,
                Id = t.Id,
                Name = t.Name,
                ImageFileName = t.LogoFileName
            }, cancellationToken);

        return teams
            .Concat(players)
            .Concat(coaches)
            .Concat(tournaments)
            .OrderBy(t => t.Name)
            .ToArray();
    }
}
