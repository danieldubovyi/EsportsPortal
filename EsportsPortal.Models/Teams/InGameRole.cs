using System.ComponentModel;
using System.Reflection;

namespace EsportsPortal.Models.Teams;
public enum InGameRole
{
    Rifler,
    AWPer,
    [Description("In-game leader")]
    InGameLeader
}

public static class RoleExtensions
{
    public static string GetDescription(this InGameRole role)
    {
        var enumString = role.ToString();
        return typeof(InGameRole).GetField(enumString)?.GetCustomAttribute<DescriptionAttribute>()?.Description
            ?? enumString;
    }
}
