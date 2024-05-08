using EsportsPortal.Models.Matches;

namespace EsportsPortal.Infrastructure.EFCore.Seed;
internal class MatchesSeed : ISeed
{
    public void Run(EsportsPortalDbContext dbContext)
    {
        var maps = dbContext.Maps.ToArray();
        var location = dbContext.Locations.First(l => l.City == "Paris");
        var tournament = new Tournament
        {
            Name = "BLAST.tv Paris Major 2023",
            StartDate = new DateOnly(2023, 5, 13),
            EndDate = new DateOnly(2023, 5, 21),
            Location = location,
            PrizePool = 1250000,
            LogoFileName = "Major2023.svg"
        };

        var teams = dbContext.Teams.ToArray();

        dbContext.TournamentTeams.AddRange(teams.Select(t => new TournamentTeam { Team = t, Tournament =  tournament }));

        var match = new Match
        {
            Team1 = teams[0],
            Team2 = teams[1],
            DateTime = new DateTime(2023, 5, 13, 12, 30, 00),
            MatchFormat = MatchFormat.LAN,
            Tournament = tournament,
            Result = new MatchResult
            {
                Team1MapWins = 1,
                Team2MapWins = 0,
                WinnerTeam = teams[0]
            }
        };

        dbContext.Matchs.Add(match);

        var map = new MatchMap
        {
            Map = maps.First(m => m.Name == "Mirage"),
            Match = match,
            PickByTeam = teams[0],
            Result = new MatchMapResult
            {
                Team1RoundWins = 16,
                Team2RoundWins = 8,
                WinnerTeam = teams[0]
            }
        };

        dbContext.MatchMaps.Add(map);

        match = new Match
        {
            Team1 = teams[1],
            Team2 = teams[2],
            DateTime = new DateTime(2023, 5, 14, 14, 00, 00),
            MatchFormat = MatchFormat.LAN,
            Tournament = tournament,
            Result = new MatchResult
            {
                Team1MapWins = 1,
                Team2MapWins = 0,
                WinnerTeam = teams[1]
            }
        };

        dbContext.Matchs.Add(match);

        map = new MatchMap
        {
            Map = maps.First(m => m.Name == "Inferno"),
            Match = match,
            PickByTeam = teams[2],
            Result = new MatchMapResult
            {
                Team1RoundWins = 16,
                Team2RoundWins = 7,
                WinnerTeam = teams[1]
            }
        };

        dbContext.MatchMaps.Add(map);

        match = new Match
        {
            Team1 = teams[0],
            Team2 = teams[2],
            DateTime = new DateTime(2023, 5, 15, 19, 00, 00),
            MatchFormat = MatchFormat.LAN,
            Tournament = tournament,
            Result = new MatchResult
            {
                Team1MapWins = 0,
                Team2MapWins = 2,
                WinnerTeam = teams[2]
            }
        };

        dbContext.Matchs.Add(match);

        var matchMaps = new[]
        {
            new MatchMap
            {
                Map = maps.First(m => m.Name == "Inferno"),
                Match = match,
                PickByTeam = teams[2],
                Result = new MatchMapResult
                {
                    Team1RoundWins = 10,
                    Team2RoundWins = 16,
                    WinnerTeam = teams[2]
                }
            },
            new MatchMap
            {
                Map = maps.First(m => m.Name == "Anubis"),
                Match = match,
                PickByTeam = teams[0],
                Result = new MatchMapResult
                {
                    Team1RoundWins = 8,
                    Team2RoundWins = 16,
                    WinnerTeam = teams[2]
                }
            }
        };

        dbContext.MatchMaps.AddRange(matchMaps);

        tournament = new Tournament
        {
            Name = "BLAST Premier World Final 2023",
            StartDate = new DateOnly(2023, 12, 13),
            EndDate = new DateOnly(2023, 12, 17),
            Location = dbContext.Locations.First(l => l.City == "Abu Dhabi"),
            PrizePool = 1000000,
            LogoFileName = "BLASTPremierWorldFinal2023.webp"
        };

        dbContext.Tournaments.Add(tournament);

        dbContext.SaveChanges();
    }
}
