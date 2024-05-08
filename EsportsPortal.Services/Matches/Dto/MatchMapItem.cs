namespace EsportsPortal.Services.Matches.Dto;
public class MatchMapItem
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ImageFileName { get; set; } = default!;
    public MatchTeam Team1 { get; set; } = default!;
    public MatchTeam Team2 { get; set; } = default!;
}
