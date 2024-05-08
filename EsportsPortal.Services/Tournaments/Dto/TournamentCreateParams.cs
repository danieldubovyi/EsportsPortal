namespace EsportsPortal.Services.Tournaments.Dto;
public class TournamentCreateParams
{
    public string Name { get; set; } = default!;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int LocationId { get; set; }
    public int PrizePool { get; set; }
}
