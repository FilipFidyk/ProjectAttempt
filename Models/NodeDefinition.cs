using System;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace ProjectAttempt.Models;

public enum ComponentType
{
    Circuit,
    Logic,
    Misc
}

public class NodeDefinition
{
    public NodeDefinition(
        string name,
        string templateName,
        ComponentType componentType)
    {
        Name = name;
        ComponentType = componentType;
        PreviewTemplate = Application.Current?.FindResource(templateName) as IDataTemplate
        ?? throw new InvalidOperationException(
            "The LampTemplate resource was not found or is not an IDataTemplate.");
    }
    public string Name { get; }
    public IDataTemplate PreviewTemplate { get; }
    public ComponentType ComponentType { get; }
}
