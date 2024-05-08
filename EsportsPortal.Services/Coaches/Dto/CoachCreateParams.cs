using EsportsPortal.Models.Teams;

namespace EsportsPortal.Services.Coaches.Dto;
public class CoachCreateParams
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Nickname { get; set; } = default!;

    public DateOnly DateOfBirth { get; set; }

    public int CountryId { get; set; }

    public int? TeamId { get; set; }
}
