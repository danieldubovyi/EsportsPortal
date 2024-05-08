namespace EsportsPortal.Models.References;
public class Map : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public string ImageFileName { get; set; } = default!;
}
