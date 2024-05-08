namespace EsportsPortal.Services.Search.Dto;
public class SearchResult
{
    public SearchResultType Type { get; set; }
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? ImageFileName { get; set; }
}
