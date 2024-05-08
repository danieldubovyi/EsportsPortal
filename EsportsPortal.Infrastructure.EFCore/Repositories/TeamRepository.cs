using EsportsPortal.Models.Teams;
using Microsoft.EntityFrameworkCore;

namespace EsportsPortal.Infrastructure.EFCore.Repositories;
internal class TeamRepository(EsportsPortalDbContext dbContext)
    : EntityRepository<Team>(dbContext)
{
    public override async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await dbContext.Teams.FindAsync([id], cancellationToken)
            ?? throw new ApplicationException("Entity not found");

        using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        await dbContext.Players
            .Where(p => p.TeamId == id)
            .ExecuteUpdateAsync(setters => setters.SetProperty(p => p.TeamId, (int?)null), cancellationToken);

        await dbContext.Coaches
            .Where(c => c.TeamId == id)
            .ExecuteUpdateAsync(setters => setters.SetProperty(c => c.TeamId, (int?)null), cancellationToken);

        dbContext.Teams.Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);

        await transaction.CommitAsync(cancellationToken);
    }
}
