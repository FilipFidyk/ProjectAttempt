using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using ProjectAttempt;
using ProjectAttempt.ViewModels;


namespace ProjectAttempt.Views;

public partial class EditorView : UserControl
{
    public EditorView()
    {
        InitializeComponent();

        DragDrop.SetAllowDrop(Editor, true);
        Editor.AddHandler(DragDrop.DragOverEvent, OnDragOver);
        Editor.AddHandler(DragDrop.DropEvent, OnDrop);
    }

    private void OnDrop(object? sender, DragEventArgs e)
    {
        string? definitionName = e.DataTransfer.TryGetValue(NodeDragFormats.DefinitionId);
        if (string.IsNullOrWhiteSpace(definitionName))
            return;

        Point pointerPos = e.GetPosition(Editor);
        var evm = DataContext as EditorViewModel;

        var graphToViewport = Editor.ViewportTransform.Value;
        if (!graphToViewport.HasInverse)
            throw new InvalidOperationException("The editor viewport transform cannot be inverted.");

        Point graphPoint = graphToViewport.Invert().Transform(pointerPos);
        evm!.AddNode(definitionName, graphPoint);
    }

    private void OnDragOver(object? sender, DragEventArgs e)
    {
        string? definitionName = e.DataTransfer.TryGetValue(NodeDragFormats.DefinitionId);
        if (!string.IsNullOrWhiteSpace(definitionName))
        {
            e.DragEffects = DragDropEffects.Copy;
        }
        else
        {
            e.DragEffects = DragDropEffects.None;
        }
    }
}