using MauiApp1.Presentation.ViewModels.Base;

namespace MauiApp1.Presentation.Views;

public class BaseContentPage  : ContentPage
{
    public BaseContentPage()
    {
        NavigationPage.SetBackButtonTitle(this, string.Empty);
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is not IBaseViewModel vm)
        {
            return;
        }

        await vm.InitAsyncCommand.ExecuteAsync(null);
    }
}