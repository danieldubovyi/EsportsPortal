namespace EsportsPortal.WebApi.Identity;

public class EmailOptions
{
    public const string SectionName = "Email";

    public string From { get; set; } = default!;

    public string PickupDirectoryLocation { get; set; } = default!;
}
