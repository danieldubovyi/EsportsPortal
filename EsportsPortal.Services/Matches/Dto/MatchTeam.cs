namespace EsportsPortal.Services.Matches.Dto;
public class MatchTeam
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public string? LogoFileName { get; set; }

    public int? Points { get; set; }

    public bool? IsWinner { get; set; }
}
