namespace EsportsPortal.WebUi.Components.Tournaments;

public class TournamentDetailsModel
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? LocationId { get; set; }
    public int? PrizePool { get; set; }
}
