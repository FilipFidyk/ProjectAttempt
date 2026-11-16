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
        ComponentType componentType,
        int inputCount = 1)
    {
        if (inputCount is < 1 or > 2)
            throw new ArgumentOutOfRangeException(nameof(inputCount), "Only one or two inputs are supported.");

        Name = name;
        ComponentType = componentType;
        InputCount = inputCount;
        PreviewTemplate = Application.Current?.FindResource(templateName) as IDataTemplate
        ?? throw new InvalidOperationException(
            $"The {templateName} resource was not found or is not an IDataTemplate.");
    }
    public string Name { get; }
    public IDataTemplate PreviewTemplate { get; }
    public ComponentType ComponentType { get; }
    public int InputCount { get; }
}
