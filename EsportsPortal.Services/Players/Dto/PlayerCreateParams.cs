using EsportsPortal.Models.Teams;

namespace EsportsPortal.Services.Players.Dto;
public class PlayerCreateParams
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Nickname { get; set; } = default!;

    public DateOnly DateOfBirth { get; set; }

    public int CountryId { get; set; }

    public int? TeamId { get; set; }

    public int? Rating { get; set; }

    public InGameRole Role { get; set; }
}
