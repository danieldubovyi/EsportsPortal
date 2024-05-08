using EsportsPortal.Models.References;

namespace EsportsPortal.Models.Teams;
public abstract class TeamMember : IEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Nickname { get; set; } = default!;

    public DateOnly DateOfBirth { get; set; }

    public string? PhotoFileName { get; set; }= default!;

    public int CountryId { get; set; }

    public Country Country { get; set; } = default!;

    public int? TeamId { get; set; }

    public Team? Team { get; set; }
}
