using MauiApp1.Presentation.Views;

namespace MauiApp1.Domain.Services.NavigationService;

public class MauiNavigationService : INavigationService
{
    public async Task InitializeAsync()
    {
        // var user = Service.GetUserInfo()
        await NavigateToAsync("//" + nameof(MainPage));
    }

    public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
    {
        var shellNavigation = new ShellNavigationState(route);

        return routeParameters != null
            ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
            : Shell.Current.GoToAsync(shellNavigation);
    }

    public Task PopAsync()
    {
        return Shell.Current.GoToAsync("..");
    }
}