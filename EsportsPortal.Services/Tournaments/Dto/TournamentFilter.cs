using System.Linq.Expressions;
using EsportsPortal.Models.Matches;

namespace EsportsPortal.Services.Tournaments.Dto;
public class TournamentFilter
{
    public DateOnly? StartDateFrom { get; set; }

    public DateOnly? StartDateTo { get; set; }

    public bool? IsFinished { get; set; }

    public Expression<Func<Tournament, bool>>? GetExpression()
    {
        List<Expression<Func<Tournament, bool>>> expressions = [];

        if (StartDateFrom.HasValue)
        {
            expressions.Add(t => t.StartDate >= StartDateFrom.Value);
        }

        if (StartDateTo.HasValue)
        {
            expressions.Add(t => t.StartDate <= StartDateTo.Value);
        }

        if (IsFinished.HasValue)
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            if (IsFinished.Value)
            {
                expressions.Add(t => t.EndDate < today);
            }
            else
            {
                expressions.Add(t => t.EndDate >= today);
            }
        }

        return expressions.ToAndExpression();
    }
}
