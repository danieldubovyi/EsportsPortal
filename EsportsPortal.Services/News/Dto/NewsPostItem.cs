namespace EsportsPortal.Services.News.Dto;
public class NewsPostItem
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public DateTime PublishDate { get; set; }
    public string? ImageFileName { get; set; }
}
