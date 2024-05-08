namespace EsportsPortal.Models.Users;
public class UserSetting : IEntity
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public User? User { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Value { get; set; } = default!;
}
