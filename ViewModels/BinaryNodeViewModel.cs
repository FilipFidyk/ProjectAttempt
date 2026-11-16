using Nodify;
using ProjectAttempt.Models;

namespace ProjectAttempt.ViewModels;

public class BinaryNodeViewModel : NodeViewModel
{
    public BinaryNodeViewModel(NodeDefinition nodeDef) : base(nodeDef)
    {
        SecondLeftConnnctor = new(ConnectorPosition.Left);
    }

    public ConnectorViewModel SecondLeftConnnctor { get; }

    protected override void SetConnectorOpacity(double opacity)
    {
        base.SetConnectorOpacity(opacity);
        SecondLeftConnnctor.Opacity = opacity;
    }
}
