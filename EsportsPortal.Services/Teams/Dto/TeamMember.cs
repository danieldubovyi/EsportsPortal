namespace EsportsPortal.Services.Teams.Dto;
public abstract class TeamMember
{
    public int Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Nickname { get; set; } = default!;

    public string? PhotoFileName { get; set; } = default!;
}
