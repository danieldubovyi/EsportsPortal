using EsportsPortal.WebApi.Clients;
using Microsoft.FluentUI.AspNetCore.Components;

namespace EsportsPortal.WebUi;

internal static class Extensions
{
    public static void ShowErrors(this IToastService toastService, IEnumerable<string> errors)
    {
        foreach (var error in errors)
        {
            toastService.ShowError(error, 0);
        }
    }

    public static string GetFullName(this TeamMember member)
        => GetMemberFullName(member.FirstName, member.LastName, member.Nickname);

    public static string GetFullName(this PlayerListItem player)
        => GetMemberFullName(player.FirstName, player.LastName, player.Nickname);

    public static string GetFullName(this PlayerDetails player)
        => GetMemberFullName(player.FirstName, player.LastName, player.Nickname);

    public static string GetFullName(this CoachListItem coach)
        => GetMemberFullName(coach.FirstName, coach.LastName, coach.Nickname);

    public static string GetFullName(this CoachDetails coach)
        => GetMemberFullName(coach.FirstName, coach.LastName, coach.Nickname);

    private static string GetMemberFullName(string firstName, string lastName, string nickname)
        => $"{firstName} '{nickname}' {lastName}";

    public static string ToStringWithAge(this DateTimeOffset date)
    {
        var today = DateTimeOffset.Now.Date;
        date = date.Date;
        var age = today.Year - date.Year;
        if (date.AddYears(age) > today)
        {
            age--;
        }

        return $"{date:MMM dd, yyyy} (age {age})";
    }

    public static string GetDateRangeString(this TournamentListItem tournament)
        => GetDateRangeString(tournament.StartDate, tournament.EndDate);

    public static string GetDateRangeString(this TournamentDetails tournament)
        => GetDateRangeString(tournament.StartDate, tournament.EndDate);

    private static string GetDateRangeString(DateTimeOffset start, DateTimeOffset end)
    {
        if (start.Year == end.Year)
        {
            return $"{start: MMM dd} - {end: MMM dd}, {start: yyyy}";
        }

        return $"{start: MMM dd, yyyy} - {end: MMM dd, yyyy}";
    }

    public static T? GetEnumValue<T>(this IReadOnlyCollection<UserSettingItem> settings, string name)
        where T : struct, Enum
    {
        var setting = settings.FirstOrDefault(x => x.Name == name);
        if (setting?.Value == null)
        {
            return null;
        }

        return Enum.TryParse<T>(setting.Value, out var value) ? value : null;
    }

    public static void SetValue<T>(this IList<UserSettingItem> settings, string name, T? value)
        where T : struct
    {
        var setting = settings.FirstOrDefault(x => x.Name == name);
        if (setting == null)
        {
            setting = new UserSettingItem { Name = name };
            settings.Add(setting);
        }

        setting.Value = value?.ToString();
    }
}
