using System;
using System.Collections.Generic;
using System.Linq;
using ProjectAttempt.Models;

namespace ProjectAttempt.ViewModels;

public class ComponentPanelViewModel
{
    private IEnumerable<NodeDefinition> allNodes;
    public ComponentPanelViewModel()
    {
        allNodes = CreateNodes();
        Tabs = [
            new("All", null, allNodes),
            new("Circuit", ComponentType.Circuit, allNodes),
            new("Logic", ComponentType.Logic, allNodes)
        ];
    }


    public List<TabItemViewModel> Tabs { get; }

    public TabItemViewModel SelectedTab { get; set; }
    private IEnumerable<NodeDefinition> CreateNodes()
    {
        return [
            new("Lamp", "LampTemplate", ComponentType.Circuit)
        ];
    }
}

public class TabItemViewModel
{
    public TabItemViewModel(
        string header,
        ComponentType? componentType,
        IEnumerable<NodeDefinition> content)
    {
        Header = header;
        Content = (componentType is null) ? 
            content : 
            content.Where(x=>x.ComponentType == componentType);
    }
    public string Header { get; }
    public IEnumerable<NodeDefinition> Content { get; }
}
