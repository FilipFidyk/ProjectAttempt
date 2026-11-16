using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ProjectAttempt.Models;

namespace ProjectAttempt.Stores;

public class NodeCatalogueStore
{
    public NodeCatalogueStore()
    {
        AllNodes = [
            new("Lamp", "LampTemplate", ComponentType.Circuit)
        ];
    }
    public IEnumerable<NodeDefinition> AllNodes { get; }

    public NodeDefinition Get(string name)
    {
        return AllNodes.SingleOrDefault(x => x.Name.CompareTo(name) == 0) ??
            throw new NotImplementedException($"{name} node hasn't been implemented");
    }
}
