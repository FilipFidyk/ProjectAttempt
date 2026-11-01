using System.Collections.ObjectModel;

namespace ProjectAttempt.ViewModels;

public class EditorViewModel : ViewModelBase
{
    public ObservableCollection<NodeViewModel> Nodes { get; } = new ObservableCollection<NodeViewModel>();

    public EditorViewModel()
    {
        Nodes.Add(new NodeViewModel { Title = "Welcome" });
    }

}
