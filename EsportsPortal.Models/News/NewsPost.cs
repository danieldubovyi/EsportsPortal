namespace EsportsPortal.Models.News;
public class NewsPost : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public DateTime PublishDate { get; set; }
    public string Body { get; set; } = default!;
    public string? ImageFileName { get; set; }
}
