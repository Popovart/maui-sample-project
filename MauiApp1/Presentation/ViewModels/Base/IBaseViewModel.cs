using CommunityToolkit.Mvvm.Input;
using MauiApp1.Domain.Services.NavigationService;

namespace MauiApp1.Presentation.ViewModels.Base;

public interface IBaseViewModel : IQueryAttributable
{
    public INavigationService NavigationService { get; }

    public IAsyncRelayCommand InitAsyncCommand { get; }

    public bool IsBusy { get; }

    public bool IsInitialized { get; }

    Task InitializeAsync();
}
