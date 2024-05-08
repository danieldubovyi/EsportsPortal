namespace EsportsPortal.Services.News.Dto;
public class NewsPostCreateParams
{
    public string Title { get; set; } = default!;
    public string Body { get; set; } = default!;
    public DateTime PublishDate { get; set; }
}
