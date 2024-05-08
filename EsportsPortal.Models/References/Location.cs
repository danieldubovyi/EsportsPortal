namespace EsportsPortal.Models.References;
public class Location : IEntity
{
    public int Id { get; set; }

    public string City { get; set; } = default!;

    public int CountryId { get; set; }

    public Country? Country { get; set; }
}
