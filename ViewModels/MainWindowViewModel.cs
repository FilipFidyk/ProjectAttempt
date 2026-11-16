namespace ProjectAttempt.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ComponentPanelViewModel ComponentPanelViewModel { get; }
    public EditorViewModel EditorViewModel { get; }
    public MainWindowViewModel()
    {
        ComponentPanelViewModel = new();
        EditorViewModel = new();
    }
}
