using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectAttempt.ViewModels;

public partial class ConnectionViewModel : ViewModelBase
{
    [ObservableProperty]
    private ConnectorViewModel source;

    [ObservableProperty]
    private ConnectorViewModel target;

    public ConnectionViewModel(ConnectorViewModel s, ConnectorViewModel t)
    {
        source = s;
        target = t;

        Source.IsConnected = true;
        Target.IsConnected = true;
    }
}
