using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectAttempt.ViewModels;

public partial class NodeViewModel2 : ViewModelBase
{
    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private bool isSelected;
    private Point _location;

    public NodeViewModel2() { }

    public NodeViewModel2(
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
    public ConnectorViewModel? LeftConnector => Input.FirstOrDefault();
    public ConnectorViewModel? RightConnector => Output.FirstOrDefault();

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
