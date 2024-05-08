using EsportsPortal.Models.References;

namespace EsportsPortal.Infrastructure.EFCore.Seed;
internal class ReferenceSeed : ISeed
{
    public void Run(EsportsPortalDbContext dbContext)
    {
        dbContext.Regions.AddRange([
            new Region { Name = "Europe", FlagFileName = "EU.webp" },
            new Region { Name = "North America", FlagFileName = "North America.png" },
            new Region { Name = "South America", FlagFileName = "South America.png" },
            new Region { Name = "CIS", FlagFileName = "CIS.png" },
            new Region { Name = "China", FlagFileName = "China.png" },
        ]);

        var countries = new[]
        {
            new Country { Name = "Ukraine", FlagFileName = "UA.webp" },
            new Country { Name = "Poland", FlagFileName = "PL.webp" },
            new Country { Name = "Finland", FlagFileName = "FI.webp" },
            new Country { Name = "Hungary", FlagFileName = "HU.webp" },
            new Country { Name = "Israel", FlagFileName = "IL.webp" },
            new Country { Name = "Lithuania", FlagFileName = "LT.webp" },
            new Country { Name = "Denmark", FlagFileName = "DK.webp" },
            new Country { Name = "Romania", FlagFileName = "RO.webp" },
            new Country { Name = "Slovakia", FlagFileName = "SK.webp" },
            new Country { Name = "Latvia", FlagFileName = "LV.webp" },
            new Country { Name = "Norway", FlagFileName = "NO.webp" },
            new Country { Name = "Estonia", FlagFileName = "EE.webp" },
            new Country { Name = "France", FlagFileName = "FR.webp" },
            new Country { Name = "Brazil", FlagFileName = "BR.webp" },
            new Country { Name = "Belgium", FlagFileName = "BE.webp" },
            new Country { Name = "Sweden", FlagFileName = "SE.webp" },
            new Country { Name = "Germany", FlagFileName = "DE.webp" },
            new Country { Name = "United Kingdom", FlagFileName = "GB.webp" },
            new Country { Name = "UAE", FlagFileName = "AE.webp" },
        };
        dbContext.Countries.AddRange(countries);

        dbContext.Maps.AddRange([
            new Map { Name = "Mirage", ImageFileName = "mirage.png" },
            new Map { Name = "Inferno", ImageFileName = "inferno.png" },
            new Map { Name = "Overpass", ImageFileName = "overpass.webp" },
            new Map { Name = "Nuke", ImageFileName = "nuke.png" },
            new Map { Name = "Dust2", ImageFileName = "dust2.png" },
            new Map { Name = "Train", ImageFileName = "train.webp" },
            new Map { Name = "Cache", ImageFileName = "cache.webp" },
            new Map { Name = "Vertigo", ImageFileName = "vertigo.webp" },
            new Map { Name = "Cobblestone", ImageFileName = "cobblestone.webp" },
            new Map { Name = "Ancient", ImageFileName = "ancient.webp" },
            new Map { Name = "Anubis", ImageFileName = "anubis.png" },
        ]);

        dbContext.Locations.AddRange([
            new Location { City = "Paris", Country = countries.First(c => c.Name == "France") },
            new Location { City = "Rio de Janeiro", Country = countries.First(c => c.Name == "Brazil") },
            new Location { City = "Antwerp", Country = countries.First(c => c.Name == "Belgium") },
            new Location { City = "Stockholm", Country = countries.First(c => c.Name == "Sweden") },
            new Location { City = "Jönköping", Country = countries.First(c => c.Name == "Sweden") },
            new Location { City = "Berlin", Country = countries.First(c => c.Name == "Germany") },
            new Location { City = "Cologne", Country = countries.First(c => c.Name == "Germany") },
            new Location { City = "Katowice", Country = countries.First(c => c.Name == "Poland") },
            new Location { City = "Krakow", Country = countries.First(c => c.Name == "Poland") },
            new Location { City = "London", Country = countries.First(c => c.Name == "United Kingdom") },
            new Location { City = "Abu Dhabi", Country = countries.First(c => c.Name == "UAE") },
        ]);

        dbContext.SaveChanges();
    }
}
