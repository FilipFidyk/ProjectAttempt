using ProjectAttempt.Stores;

namespace ProjectAttempt.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ComponentPanelViewModel ComponentPanelViewModel { get; }
    public EditorViewModel EditorViewModel { get; }
    public MainWindowViewModel(NodeCatalogueStore ncs)
    {
        ComponentPanelViewModel = new(ncs);
        EditorViewModel = new(ncs);
    }
}
