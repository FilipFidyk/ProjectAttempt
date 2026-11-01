using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectAttempt.ViewModels;

public partial class ConnectorViewModel : ViewModelBase
{
    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private Point anchor;

    [ObservableProperty]
    private bool isConnected;
}
