using EsportsPortal.Infrastructure.EFCore.Seed;

using var _ = new SeedRunner()
    .Run<ReferenceSeed>()
    .Run<TeamsSeed>()
    .Run<UsersSeed>()
    .Run<MatchesSeed>();
