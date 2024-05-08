namespace EsportsPortal.Infrastructure.EFCore.Seed;
internal interface ISeed
{
    void Run(EsportsPortalDbContext dbContext);
}
