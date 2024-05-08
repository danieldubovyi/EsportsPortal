namespace EsportsPortal.Models.References;
public class Region : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public string FlagFileName { get; set; } = default!;
}
