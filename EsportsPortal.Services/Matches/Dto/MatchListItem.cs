using EsportsPortal.Models.Matches;

namespace EsportsPortal.Services.Matches.Dto;
public class MatchListItem
{
    public int Id { get; set; }

    public DateTime DateTime { get; set; }

    public MatchTeam Team1 { get; set; } = default!;

    public MatchTeam Team2 { get; set; } = default!;

    public MatchFormat MatchFormat { get; set; }
}
