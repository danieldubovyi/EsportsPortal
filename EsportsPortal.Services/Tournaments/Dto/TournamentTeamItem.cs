namespace EsportsPortal.Services.Tournaments.Dto;
public class TournamentTeamItem
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public string? LogoFileName { get; set; }

    public string RegionName { get; set; } = default!;

    public string RegionFlagFileName { get; set; } = default!;

    public int? Place { get; set; }

    public int? Prize { get; set; }
}
