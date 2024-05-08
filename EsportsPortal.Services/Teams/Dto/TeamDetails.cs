namespace EsportsPortal.Services.Teams.Dto;
public class TeamDetails
{
    public int Id { get; set; }

    public int Ranking { get; set; }

    public string Name { get; set; } = default!;

    public string? LogoFileName { get; set; }

    public int RegionId { get; set; }

    public string RegionName { get; set; } = default!;

    public string RegionFlagFileName { get; set; } = default!;
}
