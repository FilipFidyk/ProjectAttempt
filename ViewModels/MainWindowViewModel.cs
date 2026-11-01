namespace ProjectAttempt.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public EditorViewModel EditorViewModel { get; }
    public MainWindowViewModel()
    {
        EditorViewModel = new();
    }
}
