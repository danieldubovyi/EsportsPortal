namespace EsportsPortal.Services.Tournaments.Dto;
public class TournamentDetails
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int LocationId { get; set; }

    public string City { get; set; } = default!;

    public string CountryName { get; set; } = default!;

    public string CountryFlagFileName { get; set; } = default!;

    public int PrizePool { get; set; }

    public string? LogoFileName { get; set; }
}
