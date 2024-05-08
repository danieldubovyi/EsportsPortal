using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

[assembly: InternalsVisibleTo("EsportsPortal.Infrastructure.EFCore.Seed")]

namespace EsportsPortal.Infrastructure.EFCore;
internal class EsportsPortalDbContextFactory : IDesignTimeDbContextFactory<EsportsPortalDbContext>
{
    public EsportsPortalDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EsportsPortalDbContext>();
        optionsBuilder.UseSqlServer("data source=.;initial catalog=EsportsPortal;Integrated Security=true;Encrypt=False;TrustServerCertificate=True");

        return new EsportsPortalDbContext(optionsBuilder.Options);
    }
}
