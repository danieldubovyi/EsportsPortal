using EsportsPortal.Models.Teams;

namespace EsportsPortal.Infrastructure.EFCore.Seed;
internal class TeamsSeed : ISeed
{
    public void Run(EsportsPortalDbContext dbContext)
    {
        #region Natus Vincere
        var team = new Team
        {
            Name = "Natus Vincere",
            LogoFileName = "NAVI.svg",
            Ranking = 8,
            Region = dbContext.Regions.First(r => r.Name == "Europe")
        };
        dbContext.Teams.Add(team);

        dbContext.Players.AddRange([
            new Player
            {
                FirstName = "Aleksi",
                LastName = "Virolainen",
                Nickname = "Aleksib",
                PhotoFileName = "Aleksib.webp",
                DateOfBirth = new DateOnly(1997, 3, 30),
                Country = dbContext.Countries.First(c => c.Name == "Finland"),
                Rating = 528,
                Role = InGameRole.InGameLeader,
                Team = team
            },
            new Player
            {
                FirstName = "Valerij",
                LastName = "Vakhovsjkyj",
                Nickname = "b1t",
                PhotoFileName = "b1t.webp",
                DateOfBirth = new DateOnly(2003, 1, 5),
                Country = dbContext.Countries.First(c => c.Name == "Ukraine"),
                Rating = 579,
                Role = InGameRole.Rifler,
                Team = team
            },
            new Player
            {
                FirstName = "Justinas",
                LastName = "Lekavicius",
                Nickname = "jL",
                PhotoFileName = "jL.webp",
                DateOfBirth = new DateOnly(1999, 9, 29),
                Country = dbContext.Countries.First(c => c.Name == "Lithuania"),
                Rating = 496,
                Role = InGameRole.Rifler,
                Team = team
            },
            new Player
            {
                FirstName = "Ivan",
                LastName = "Mihai",
                Nickname = "iM",
                PhotoFileName = "iM.webp",
                DateOfBirth = new DateOnly(1999, 7, 29),
                Country = dbContext.Countries.First(c => c.Name == "Romania"),
                Rating = 491,
                Role = InGameRole.Rifler,
                Team = team
            },
            new Player
            {
                FirstName = "Ihor",
                LastName = "Zhdanov",
                Nickname = "w0nderful",
                PhotoFileName = "w0nderful.webp",
                DateOfBirth = new DateOnly(2004, 12, 14),
                Country = dbContext.Countries.First(c => c.Name == "Ukraine"),
                Rating = 368,
                Role = InGameRole.AWPer,
                Team = team
            }
        ]);

        dbContext.Coaches.AddRange([
            new Coach
            {
                FirstName = "Andrij",
                LastName = "Ghorodensjkyj",
                Nickname = "B1ad3",
                PhotoFileName = "B1ad3.jpg",
                DateOfBirth = new DateOnly(1986, 11, 11),
                Country = dbContext.Countries.First(c => c.Name == "Ukraine"),
                Team = team
            }
        ]);
        #endregion Natus Vincere

        #region MOUZ
        team = new Team
        {
            Name = "MOUZ",
            LogoFileName = "MOUZ.webp",
            Ranking = 3,
            Region = dbContext.Regions.First(r => r.Name == "Europe")
        };
        dbContext.Teams.Add(team);

        dbContext.Players.AddRange([
            new Player
            {
                FirstName = "Ádám",
                LastName = "Torzsás",
                Nickname = "torzsi",
                PhotoFileName = "torzsi.webp",
                DateOfBirth = new DateOnly(2002, 5, 17),
                Country = dbContext.Countries.First(c => c.Name == "Hungary"),
                Rating = 578,
                Role = InGameRole.AWPer,
                Team = team
            },
            new Player
            {
                FirstName = "Dorian",
                LastName = "Berman",
                Nickname = "xertioN",
                PhotoFileName = "xertioN.webp",
                DateOfBirth = new DateOnly(2004, 7, 22),
                Country = dbContext.Countries.First(c => c.Name == "Israel"),
                Rating = 548,
                Role = InGameRole.Rifler,
                Team = team
            },
            new Player
            {
                FirstName = "Kamil",
                LastName = "Szkaradek",
                Nickname = "siuhy",
                PhotoFileName = "siuhy.webp",
                DateOfBirth = new DateOnly(2002, 8, 26),
                Country = dbContext.Countries.First(c => c.Name == "Poland"),
                Rating = 463,
                Role = InGameRole.InGameLeader,
                Team = team
            },
            new Player
            {
                FirstName = "Jimi",
                LastName = "Salo",
                Nickname = "Jimpphat",
                PhotoFileName = "Jimpphat.webp",
                DateOfBirth = new DateOnly(2006, 9, 9),
                Country = dbContext.Countries.First(c => c.Name == "Finland"),
                Rating = 409,
                Role = InGameRole.Rifler,
                Team = team
            }
        ]);

        dbContext.Coaches.AddRange([
            new Coach
            {
                FirstName = "Dennis",
                LastName = "Benthin Nielsen",
                Nickname = "sycrone",
                PhotoFileName = "sycrone.webp",
                DateOfBirth = new DateOnly(2000, 1, 1),
                Country = dbContext.Countries.First(c => c.Name == "Denmark"),
                Team = team
            }
        ]);
        #endregion MOUZ

        #region FaZe
        team = new Team
        {
            Name = "FaZe",
            LogoFileName = "FaZe.svg",
            Ranking = 1,
            Region = dbContext.Regions.First(r => r.Name == "Europe")
        };
        dbContext.Teams.Add(team);

        dbContext.Players.AddRange([
            new Player
            {
                FirstName = "Finn",
                LastName = "Andersen",
                Nickname = "karrigan",
                PhotoFileName = "karrigan.webp",
                DateOfBirth = new DateOnly(1990, 4, 14),
                Country = dbContext.Countries.First(c => c.Name == "Denmark"),
                Rating = null,
                Role = InGameRole.InGameLeader,
                Team = team
            },
            new Player
            {
                FirstName = "Håvard",
                LastName = "Nygaard",
                Nickname = "rain",
                PhotoFileName = "rain.webp",
                DateOfBirth = new DateOnly(1994, 8, 27),
                Country = dbContext.Countries.First(c => c.Name == "Norway"),
                Rating = 13,
                Role = InGameRole.Rifler,
                Team = team
            },
            new Player
            {
                FirstName = "David",
                LastName = "Čerňanský",
                Nickname = "frozen",
                PhotoFileName = "frozen.webp",
                DateOfBirth = new DateOnly(2002, 7, 18),
                Country = dbContext.Countries.First(c => c.Name == "Slovakia"),
                Rating = null,
                Role = InGameRole.Rifler,
                Team = team
            },
            new Player
            {
                FirstName = "Helvijs",
                LastName = "Saukants",
                Nickname = "broky",
                PhotoFileName = "broky.webp",
                DateOfBirth = new DateOnly(2001, 2, 14),
                Country = dbContext.Countries.First(c => c.Name == "Latvia"),
                Rating = null,
                Role = InGameRole.AWPer,
                Team = team
            },
            new Player
            {
                FirstName = "Robin",
                LastName = "Kool",
                Nickname = "ropz",
                PhotoFileName = "ropz.webp",
                DateOfBirth = new DateOnly(1999, 12, 22),
                Country = dbContext.Countries.First(c => c.Name == "Estonia"),
                Rating = null,
                Role = InGameRole.Rifler,
                Team = team
            }
        ]);

        dbContext.Coaches.AddRange([
            new Coach
            {
                FirstName = "Filip",
                LastName = "Kubski",
                Nickname = "NEO",
                PhotoFileName = "NEO.webp",
                DateOfBirth = new DateOnly(1987, 6, 15),
                Country = dbContext.Countries.First(c => c.Name == "Latvia"),
                Team = team
            }
        ]);
        #endregion MOUZ

        dbContext.SaveChanges();
    }
}
