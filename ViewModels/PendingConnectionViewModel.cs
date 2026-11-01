using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace ProjectAttempt.ViewModels;

public class PendingConnectionViewModel
{
    private readonly EditorViewModel _editor;
    private ConnectorViewModel _source;

    public PendingConnectionViewModel(EditorViewModel editor)
    {
        _editor = editor;
        StartCommand = new RelayCommand<ConnectorViewModel>(source => _source = source);
        FinishCommand = new RelayCommand<ConnectorViewModel>(target =>
        {
            if (target != null)
                _editor.Connect(_source, target);
        });
    }

    public ICommand StartCommand { get; }
    public ICommand FinishCommand { get; }
}
