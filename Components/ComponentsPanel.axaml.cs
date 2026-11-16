using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using ProjectAttempt.Models;

namespace ProjectAttempt.Components;

public partial class ComponentsPanel : UserControl
{
    public ComponentsPanel()
    {
        InitializeComponent();

        AddHandler(
            InputElement.PointerPressedEvent,
            OnPointerPressed,
            Avalonia.Interactivity.RoutingStrategies.Bubble,
            true);
    }

    private async void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            return;

        if (e.Source is not Control { DataContext: NodeDefinition definition })
            return;

        using var dragData = new DataTransfer();
        dragData.Add(DataTransferItem.Create<string>(
            NodeDragFormats.DefinitionId,
            definition.Name));

        await DragDrop.DoDragDropAsync(e, dragData, DragDropEffects.Copy);
    }
}