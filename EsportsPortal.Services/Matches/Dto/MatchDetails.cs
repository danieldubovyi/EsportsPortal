using EsportsPortal.Models.Matches;

namespace EsportsPortal.Services.Matches.Dto;
public class MatchDetails
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public MatchTeam Team1 { get; set; } = default!;
    public MatchTeam Team2 { get; set; } = default!;
    public int TournamentId { get; set; }
    public string TournamentName { get; set; } = default!;
    public string? TournamentLogoFileName { get; set; } = default!;
    public string City { get; set; } = default!;
    public string CountryName { get; set; } = default!;
    public string CountryFlagFileName { get; set; } = default!;
    public MatchFormat MatchFormat { get; set; }
}
