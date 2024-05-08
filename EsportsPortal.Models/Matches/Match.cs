using EsportsPortal.Models.Teams;

namespace EsportsPortal.Models.Matches;
public class Match : IEntity
{
    public int Id { get; set; }

    public int Team1Id { get; set; }

    public Team? Team1 { get; set; }

    public int Team2Id { get; set; }

    public Team? Team2 { get; set; }

    public DateTime DateTime { get; set; }

    public int TournamentId { get; set; }

    public Tournament? Tournament { get; set; }

    public MatchFormat MatchFormat { get; set; }

    public MatchResult? Result { get; set; }
}
