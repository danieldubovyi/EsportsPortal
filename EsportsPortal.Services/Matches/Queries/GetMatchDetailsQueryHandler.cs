using EsportsPortal.Models.Matches;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Services.Matches.Dto;
using MediatR;

namespace EsportsPortal.Services.Matches.Queries;
public record GetMatchDetailsQuery(int MatchId) : IRequest<MatchDetails>;

internal class GetMatchDetailsQueryHandler(IEntityRepository<Match> matchRepository)
    : IRequestHandler<GetMatchDetailsQuery, MatchDetails>
{
    public async Task<MatchDetails> Handle(GetMatchDetailsQuery request, CancellationToken cancellationToken)
    {
        return await matchRepository.GetAsync(request.MatchId,
            m => new MatchDetails
            {
                Id = m.Id,
                DateTime = m.DateTime,
                Team1 = new MatchTeam
                {
                    Id = m.Team1Id,
                    Name = m.Team1!.Name,
                    LogoFileName = m.Team1!.LogoFileName,
                    Points = m.Result != null ? m.Result.Team1MapWins : null,
                    IsWinner = m.Result != null ? m.Result.WinnerTeamId == m.Team1Id : null
                },
                Team2 = new MatchTeam
                {
                    Id = m.Team2Id,
                    Name = m.Team2!.Name,
                    LogoFileName = m.Team2!.LogoFileName,
                    Points = m.Result != null ? m.Result.Team2MapWins : null,
                    IsWinner = m.Result != null ? m.Result.WinnerTeamId == m.Team2Id : null
                },
                TournamentId = m.TournamentId,
                TournamentName = m.Tournament!.Name,
                TournamentLogoFileName = m.Tournament.LogoFileName,
                City = m.Tournament!.Location!.City,
                CountryName = m.Tournament!.Location!.Country!.Name,
                CountryFlagFileName = m.Tournament!.Location!.Country!.FlagFileName,
                MatchFormat = m.MatchFormat
            }, cancellationToken);
    }
}
