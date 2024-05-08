namespace EsportsPortal.Models.Teams;
public class Player : TeamMember
{
    public int? Rating { get; set; }

    public InGameRole Role { get; set; }
}
