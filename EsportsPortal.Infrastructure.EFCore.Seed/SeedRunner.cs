namespace EsportsPortal.Infrastructure.EFCore.Seed;
internal class SeedRunner : IDisposable
{
    private readonly EsportsPortalDbContext dbContext;

    public SeedRunner()
    {
        dbContext = new EsportsPortalDbContextFactory().CreateDbContext([]);
    }

    public SeedRunner Run<TSeed>() where TSeed : ISeed, new()
    {
        Console.Write($"Running {typeof(TSeed).Name} seed.....");
        new TSeed().Run(dbContext);
        Console.WriteLine("Done");
        return this;
    }

    public void Dispose()
    {
        dbContext?.Dispose();
    }
}
