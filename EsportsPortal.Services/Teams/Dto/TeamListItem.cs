namespace EsportsPortal.Services.Teams.Dto;
public class TeamListItem
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public int Ranking { get; set; }

    public string? LogoFileName { get; set; }

    public string RegionName { get; set; } = default!;

    public string RegionFlagFileName { get; set; } = default!;
}
