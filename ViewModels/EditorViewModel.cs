using System;
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

        var node1 = new NodeViewModel2
        {
            Location = new Point(100, 100),
            Input = [
                new ConnectorViewModel
                {
                    ConnectorPosition = ConnectorPosition.Left
                }
            ],
            Output = [
                new ConnectorViewModel
                {
                    ConnectorPosition = ConnectorPosition.Right
                }
            ]
        };

        var node2 = new NodeViewModel2
        {
            Location = new Point(10, 10),
            Input = [
                new ConnectorViewModel
                {
                    ConnectorPosition = ConnectorPosition.Left
                }
            ],
            Output = [
                new ConnectorViewModel
                {
                    ConnectorPosition = ConnectorPosition.Right
                }
            ]
        };

        Nodes.Add(node1);
        Nodes.Add(node2);
    }


    public ObservableCollection<NodeViewModel2> Nodes { get; } = [];
    public ObservableCollection<ConnectionViewModel> Connections { get; } = [];

    public PendingConnectionViewModel PendingConnection { get; }

    public ICommand DisconnectConnectorCommand { get; }

    public void AddNode(string definitionName, Point point)
    {
        NodeDefinition nodeDef = _ncs.Get(definitionName);
        NodeViewModel2 nvm2 = new("text", [], [])
        {
            Location = point
        };
        Nodes.Add(nvm2);
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
