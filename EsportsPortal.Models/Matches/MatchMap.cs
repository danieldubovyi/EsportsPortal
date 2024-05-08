using EsportsPortal.Models.References;
using EsportsPortal.Models.Teams;

namespace EsportsPortal.Models.Matches;
public class MatchMap : IEntity
{
    public int Id { get; set; }

    public int MatchId { get; set; }

    public Match? Match { get; set; }

    public int MapId { get; set; }

    public Map? Map { get; set; }

    public int? PickByTeamId { get; set; }

    public Team? PickByTeam { get; set; }

    public MatchMapResult? Result { get; set; }
}
