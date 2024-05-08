using System.Linq.Expressions;
using EsportsPortal.Models.Matches;

namespace EsportsPortal.Services.Matches.Dto;
public class MatchFilter
{
    public DateOnly? From { get; set; }

    public DateOnly? To { get; set; }

    public int? TournamentId { get; set; }

    public int? TeamId { get; set; }

    public bool? IsFinished { get; set; }

    public Expression<Func<Match, bool>>? GetExpression()
    {
        List<Expression<Func<Match, bool>>> expressions = [];

        if (From.HasValue)
        {
            expressions.Add(m => m.DateTime >= From.Value.ToDateTime(TimeOnly.MinValue));
        }

        if (To.HasValue)
        {
            expressions.Add(m => m.DateTime <= To.Value.ToDateTime(TimeOnly.MaxValue));
        }

        if (IsFinished.HasValue)
        {
            if (IsFinished.Value)
            {
                expressions.Add(m => m.Result != null);
            }
            else
            {
                expressions.Add(m => m.Result == null);
            }
        }

        if (TournamentId.HasValue)
        {
            expressions.Add(m => m.TournamentId == TournamentId.Value);
        }

        if (TeamId.HasValue)
        {
            expressions.Add(m => m.Team1Id == TeamId.Value || m.Team2Id == TeamId.Value);
        }

        return expressions.ToAndExpression();
    }
}
