using EsportsPortal.Models.Teams;

namespace EsportsPortal.Models.Matches;
public class TournamentTeam : IEntity
{
    public int Id { get; set; }

    public int TournamentId { get; set; }

    public Tournament? Tournament { get; set; }

    public int TeamId { get; set; }

    public Team? Team { get; set; }

    public int? Place { get; set; }

    public int? Prize { get; set; }
}
