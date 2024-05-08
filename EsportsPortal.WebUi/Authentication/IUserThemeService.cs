using Microsoft.FluentUI.AspNetCore.Components;

namespace EsportsPortal.WebUi.Authentication;

public interface IUserThemeService
{
    Task ApplayUserThemeSettingsAsync();

    Task<ServiceResponse> SaveThemeSettingsAsync(OfficeColor? color, DesignThemeModes? mode);

    Task ResetThemeSettingsAsync();
}
