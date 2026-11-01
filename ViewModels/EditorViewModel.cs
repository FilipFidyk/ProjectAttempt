using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Avalonia;
using CommunityToolkit.Mvvm.Input;
using Nodify;

namespace ProjectAttempt.ViewModels;

public class EditorViewModel : ViewModelBase
{
    public EditorViewModel()
    {
        PendingConnection = new(this);
        DisconnectConnectorCommand = new RelayCommand<ConnectorViewModel>(Disconnect);

        var node1 = new NodeViewModel
        {
            Title = "Node1",
            Location = new Point(10, 10),
            Input = [
                new ConnectorViewModel {
                    Title = "In"
                }
            ],
            Output = [
                new ConnectorViewModel {
                    Title = "Out"
                }
            ]
        };

        var node2 = new NodeViewModel
        {
            Title = "Node2",
            Location = new Point(10, 50),
            Input = [
                new ConnectorViewModel {
                    Title = "In"
                }
            ]
        };

        Nodes.Add(node1);
        Nodes.Add(node2);

        Connections.Add(new ConnectionViewModel(
            node1.Output[0],
            node2.Input[0]
        ));
    }


    public ObservableCollection<NodeViewModel> Nodes { get; } = [];
    public ObservableCollection<ConnectionViewModel> Connections { get; } = [];

    public PendingConnectionViewModel PendingConnection { get; }

    public ICommand DisconnectConnectorCommand { get; }

    public void Connect(ConnectorViewModel source, ConnectorViewModel target)
    {
        if (source != target)
        {
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
