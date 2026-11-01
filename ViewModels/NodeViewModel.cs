using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectAttempt.ViewModels;

public partial class NodeViewModel : ViewModelBase
{
    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private Point location;

    public NodeViewModel() { }

    public NodeViewModel(
        string title,
        ObservableCollection<ConnectorViewModel> input,
        ObservableCollection<ConnectorViewModel> output)
    {
        Title = title;
        Input = input;
        Output = output;
    }

    public ObservableCollection<ConnectorViewModel> Input { get; init; } = [];
    public ObservableCollection<ConnectorViewModel> Output { get; init; } = [];




}
