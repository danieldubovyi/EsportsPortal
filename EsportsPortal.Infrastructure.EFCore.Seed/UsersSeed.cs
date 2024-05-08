using EsportsPortal.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace EsportsPortal.Infrastructure.EFCore.Seed;
internal class UsersSeed : ISeed
{
    public void Run(EsportsPortalDbContext dbContext)
    {
        var adminUser = new User
        {
            Id = "1ca5cce9-854b-4cb9-a384-4434fac9d109",
            Email = "admin@esports.portal",
            EmailConfirmed = true,
            UserName = "admin@esports.portal",
            NormalizedEmail = "ADMIN@ESPORTS.PORTAL",
            NormalizedUserName = "ADMIN@ESPORTS.PORTAL",
            PasswordHash = "AQAAAAIAAYagAAAAEOd0RdTRHK2LjfPYfQR7jPpeDu3suEGiTlYeeoFX5rah6UJEvC3JK2LPp4kq0nFUPA==", // !Two34
            SecurityStamp = "WK7TJMTSWNNOEK6AKFL74SN2QWCOMWTQ",
            ConcurrencyStamp = "32fe2243-27d9-490c-a258-a257baa1b99b",
            LockoutEnabled = true,

        };
        dbContext.Users.Add(adminUser);
        dbContext.UserRoles.Add(new IdentityUserRole<string> { RoleId = "2e7c776d-803d-4483-83e4-4727c0db0142", UserId = "1ca5cce9-854b-4cb9-a384-4434fac9d109" });

        dbContext.SaveChanges();
    }
}
