using EsportsPortal.Models.References;

namespace EsportsPortal.Models.Matches;
public class Tournament : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public int LocationId { get; set; }

    public Location? Location { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int PrizePool { get; set; }

    public string? LogoFileName { get; set; }
}
