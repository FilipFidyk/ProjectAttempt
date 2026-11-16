using System;
using Avalonia.Input;

namespace ProjectAttempt;

internal static class NodeDragFormats
{
    public static readonly DataFormat<string> DefinitionId =
        DataFormat.CreateStringApplicationFormat("ProjectAttempt.NodeDefinitionId");
}
