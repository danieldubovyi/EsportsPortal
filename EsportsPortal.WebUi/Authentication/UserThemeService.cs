using Blazored.LocalStorage;
using EsportsPortal.WebApi.Clients;
using EsportsPortal.WebUi.Pages.Settings;
using Microsoft.FluentUI.AspNetCore.Components;

namespace EsportsPortal.WebUi.Authentication;

internal class UserThemeService(
    UsersClient usersClient,
    DataSource dataSource,
    ILocalStorageService localStorage) : IUserThemeService
{
    public async Task ApplayUserThemeSettingsAsync()
    {
        var settings = await usersClient.GetSettingsAsync();
        var color = settings.GetEnumValue<OfficeColor>(SettingNames.ThemeColor);
        var mode = settings.GetEnumValue<DesignThemeModes>(SettingNames.ThemeMode);

        var themeSettings = new { mode = mode?.ToString().ToLower(), primaryColor = color?.ToString().ToLower() };
        await localStorage.SetItemAsync("theme", themeSettings);
    }

    public async Task ResetThemeSettingsAsync()
    {
        await localStorage.RemoveItemAsync("theme");
    }

    public async Task<ServiceResponse> SaveThemeSettingsAsync(OfficeColor? color, DesignThemeModes? mode)
    {
        return await dataSource.RunAction(async () =>
        {
            var settings = new List<UserSettingItem>();
            settings.SetValue(SettingNames.ThemeColor, color);
            settings.SetValue(SettingNames.ThemeMode, mode);

            await usersClient.SetUserSettingsAsync(settings);
        });
    }
}
