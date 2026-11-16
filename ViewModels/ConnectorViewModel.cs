using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using Nodify;

namespace ProjectAttempt.ViewModels;

public partial class ConnectorViewModel : ViewModelBase
{
    public ConnectorViewModel(ConnectorPosition position)
    {
        connectorPosition = position;
    }
    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private Point anchor;

    [ObservableProperty]
    private bool isConnected;

    [ObservableProperty]
    private double opacity;

    [ObservableProperty]
    private ConnectorPosition connectorPosition;
}
