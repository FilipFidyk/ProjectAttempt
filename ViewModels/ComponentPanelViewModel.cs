using System;
using System.Collections.Generic;
using System.Linq;
using ProjectAttempt.Models;
using ProjectAttempt.Stores;

namespace ProjectAttempt.ViewModels;

public class ComponentPanelViewModel
{
    private readonly NodeCatalogueStore _ncs;
    public ComponentPanelViewModel(NodeCatalogueStore ncs)
    {
        _ncs = ncs;
        Tabs = [
            new("All", null, ncs.AllNodes),
            new("Circuit", ComponentType.Circuit, ncs.AllNodes),
            new("Logic", ComponentType.Logic, ncs.AllNodes)
        ];
    }


    public List<TabItemViewModel> Tabs { get; }

    public TabItemViewModel SelectedTab { get; set; }
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
            content.Where(x => x.ComponentType == componentType);
    }
    public string Header { get; }
    public IEnumerable<NodeDefinition> Content { get; }
}
