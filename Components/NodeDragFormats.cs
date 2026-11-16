using System;
using Avalonia.Input;

namespace ProjectAttempt.Components;

internal static class NodeDragFormats
{
    public static readonly DataFormat<string> DefinitionId =
        DataFormat.CreateStringApplicationFormat("ProjectAttempt.NodeDefinitionId");
}
