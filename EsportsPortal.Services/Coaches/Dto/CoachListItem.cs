namespace EsportsPortal.Services.Coaches.Dto;
public class CoachListItem
{
    public int Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Nickname { get; set; } = default!;

    public string? PhotoFileName { get; set; }

    public string? TeamName { get; set; }

    public string? TeamLogoFileName { get; set; }
}
