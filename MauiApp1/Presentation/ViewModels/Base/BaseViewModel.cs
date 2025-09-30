using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Domain.Services.NavigationService;

namespace MauiApp1.Presentation.ViewModels.Base;

public abstract partial class BaseViewModel : ObservableObject, IBaseViewModel
{
    private long _isBusy;
    
    [ObservableProperty] private bool _isInitialized;

    public BaseViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;

        InitAsyncCommand =
            new AsyncRelayCommand(
                async () =>
                {
                    await IsBusyFor(InitializeAsync);
                    IsInitialized = true;
                },
                AsyncRelayCommandOptions.FlowExceptionsToTaskScheduler);
    }
    
    public INavigationService NavigationService { get; }
    public IAsyncRelayCommand InitAsyncCommand { get; }

    public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
    {
    }

    public bool IsBusy => Interlocked.Read(ref _isBusy) > 0;
    
    public virtual Task InitializeAsync()
    {
        return Task.CompletedTask;
    }
    
    protected async Task IsBusyFor(Func<Task> unitOfWork)
    {
        Interlocked.Increment(ref _isBusy);
        OnPropertyChanged(nameof(IsBusy));

        try
        {
            await Task.Delay(1000);
            await unitOfWork();
        }
        finally
        {
            Interlocked.Decrement(ref _isBusy);
            OnPropertyChanged(nameof(IsBusy));
        }
    }
}
