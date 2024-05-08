using EsportsPortal.Models.Matches;
using EsportsPortal.Models.News;
using EsportsPortal.Models.References;
using EsportsPortal.Models.Teams;
using EsportsPortal.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EsportsPortal.Infrastructure.EFCore;
public class EsportsPortalDbContext(DbContextOptions<EsportsPortalDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Team> Teams { get; set; }

    public DbSet<Region> Regions { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<Player> Players { get; set; }

    public DbSet<Coach> Coaches { get; set; }

    public DbSet<Match> Matchs { get; set; }

    public DbSet<MatchMap> MatchMaps { get; set; }

    public DbSet<Tournament> Tournaments { get; set; }

    public DbSet<TournamentTeam> TournamentTeams { get; set; }

    public DbSet<Location> Locations { get; set; }

    public DbSet<Map> Maps { get; set; }

    public DbSet<UserSetting> UserSettings { get; set; }

    public DbSet<NewsPost> NewsPosts { get; set; }

    public DbSet<NewsPostTag> NewsPostTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserRole>()
            .HasData(new UserRole { Id = "2e7c776d-803d-4483-83e4-4727c0db0142", Name = UserRole.Admin, NormalizedName = UserRole.Admin.ToUpper() });

        modelBuilder.Entity<Tournament>()
            .HasMany<Match>()
            .WithOne(m => m.Tournament)
            .HasForeignKey(m => m.TournamentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Tournament>()
            .HasMany<TournamentTeam>()
            .WithOne(m => m.Tournament)
            .HasForeignKey(m => m.TournamentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Match>()
            .OwnsOne(m => m.Result);

        modelBuilder.Entity<Match>()
            .HasMany<MatchMap>()
            .WithOne(mm => mm.Match)
            .HasForeignKey(mm => mm.MatchId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MatchMap>()
            .OwnsOne(m => m.Result);

        modelBuilder.Entity<NewsPost>()
            .HasMany<NewsPostTag>()
            .WithOne(t => t.NewsPost)
            .HasForeignKey(t => t.NewsPostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
