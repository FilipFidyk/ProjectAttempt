using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls.Templates;
using CommunityToolkit.Mvvm.ComponentModel;
using ProjectAttempt.Models;

namespace ProjectAttempt.ViewModels;

public partial class NodeViewModel : ViewModelBase
{
    private Point _location;

    [ObservableProperty]
    private bool _isSelected;

    public NodeViewModel(NodeDefinition nodeDef)
    {
        _location = default;

        LeftConnector = new();
        RightConnector = new();
        DataTemplate = nodeDef.PreviewTemplate;
    }
    public ConnectorViewModel LeftConnector { get; }
    public ConnectorViewModel RightConnector { get; }

    public IDataTemplate DataTemplate { get; }
    public Point Location
    {
        get => _location;
        set
        {
            var snapped = new Point(
                Math.Round(value.X / Constants.GridSize) * Constants.GridSize,
                Math.Round(value.Y / Constants.GridSize) * Constants.GridSize);

            SetProperty(ref _location, snapped);
        }
    }

}
