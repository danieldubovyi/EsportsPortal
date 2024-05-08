namespace EsportsPortal.Models.News;
public class NewsPostTag : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int NewsPostId { get; set; }
    public NewsPost? NewsPost { get; set; }
}
