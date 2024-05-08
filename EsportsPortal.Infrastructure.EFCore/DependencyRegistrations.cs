using EsportsPortal.Infrastructure.EFCore.Repositories;
using EsportsPortal.Models.Repositories;
using EsportsPortal.Models.Teams;
using Microsoft.Extensions.DependencyInjection;

namespace EsportsPortal.Infrastructure.EFCore;
public static class DependencyRegistrations
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient(typeof(IEntityRepository<>), typeof(EntityRepository<>));
        services.AddTransient<IEntityRepository<Team>, TeamRepository>();
        return services;
    }
}
