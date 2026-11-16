using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Avalonia;
using CommunityToolkit.Mvvm.Input;
using Nodify;
using ProjectAttempt.Models;
using ProjectAttempt.Stores;

namespace ProjectAttempt.ViewModels;

public class EditorViewModel : ViewModelBase
{
    private readonly NodeCatalogueStore _ncs;
    public EditorViewModel(NodeCatalogueStore ncs)
    {
        _ncs = ncs;

        PendingConnection = new(this);
        DisconnectConnectorCommand = new RelayCommand<ConnectorViewModel>(Disconnect);
    }


    public ObservableCollection<NodeViewModel> Nodes { get; } = [];
    public ObservableCollection<ConnectionViewModel> Connections { get; } = [];

    public PendingConnectionViewModel PendingConnection { get; }

    public ICommand DisconnectConnectorCommand { get; }

    public void AddNode(string definitionName, Point point)
    {
        NodeDefinition nodeDef = _ncs.Get(definitionName);
        NodeViewModel nvm = nodeDef.InputCount == 2
            ? new BinaryNodeViewModel(nodeDef)
            : new NodeViewModel(nodeDef);
        nvm.Location = point;

        Nodes.Add(nvm);
    }

    public void Connect(ConnectorViewModel source, ConnectorViewModel target)
    {
        if (source != target)
        {
            if (source.ConnectorPosition == ConnectorPosition.Left &&
                target.ConnectorPosition == ConnectorPosition.Right)
            {
                (source, target) = (target, source);
            }

            Connections.Add(new ConnectionViewModel(source, target));
        }
    }

    private void Disconnect(ConnectorViewModel connector)
    {
        var connection = Connections.First(x => x.Source == connector || x.Target == connector);
        connection.Source.IsConnected = false;  // This is not correct if there are multiple connections to the same connector
        connection.Target.IsConnected = false;
        Connections.Remove(connection);
    }

}
