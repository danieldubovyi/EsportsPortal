namespace EsportsPortal.Services.Coaches.Dto;
public class CoachDetails
{
    public int Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Nickname { get; set; } = default!;

    public string? PhotoFileName { get; set; }

    public int? TeamId { get; set; }

    public string? TeamName { get; set; }

    public string? TeamLogoFileName { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public int CountryId { get; set; }

    public string CountryName { get; set; } = default!;

    public string CountryFlagFileName { get; set; } = default!;
}
