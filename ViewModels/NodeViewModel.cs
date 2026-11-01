using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectAttempt.ViewModels;

public partial class NodeViewModel : ViewModelBase
{
    [ObservableProperty]
    private string title;
}
