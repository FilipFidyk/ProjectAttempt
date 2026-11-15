using System;
using System.Collections.ObjectModel;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectAttempt.ViewModels;

public partial class NodeViewModel : ViewModelBase
{
    [ObservableProperty]
    private string title = string.Empty;
    private Point _location;

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

    public Point Location
{
    get => _location;
    set
    {
        var snapped = new Point(
            Math.Round(value.X / 20.0) * 20.0,
            Math.Round(value.Y / 20.0) * 20.0);

        SetProperty(ref _location, snapped);
    }
}

}
