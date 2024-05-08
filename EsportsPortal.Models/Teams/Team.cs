using EsportsPortal.Models.References;

namespace EsportsPortal.Models.Teams;
public class Team : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public int Ranking { get; set; }

    public string? LogoFileName { get; set; }

    public int RegionId { get; set; }

    public Region? Region { get; set; }
}
