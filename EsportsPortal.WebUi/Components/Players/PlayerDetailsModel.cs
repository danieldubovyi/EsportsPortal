using EsportsPortal.WebApi.Clients;

namespace EsportsPortal.WebUi.Components.Players;

public class PlayerDetailsModel
{
    public int? Id { get; set; }

    public string? FirstName { get; set; } = default!;

    public string? LastName { get; set; } = default!;

    public string? Nickname { get; set; } = default!;

    public DateTime? DateOfBirth { get; set; }

    public int? CountryId { get; set; }

    public int? TeamId { get; set; }

    public int? Rating { get; set; }

    public InGameRole? Role { get; set; }
}
