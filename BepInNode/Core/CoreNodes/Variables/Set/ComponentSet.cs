using BepInNode.NodeArguments;
using System.Xml.Serialization;
using UnityEngine;
using BepInNode.CustomAttributes;

namespace BepInNode.Core.CoreNodes.Variables.Set;

public class ComponentSet : Node
{
    [XmlIgnore]
    [IgnoreProperty]
    public UnityEngine.Component ValueIn { get; set; }

    public ComponentSet()
    {
        Name = "ComponentSet";
        NodeType = NodeTypes.Variable;
        Description = "Sets the value of the Component variable";
        NodeCategory = NodeCategories.Variables;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Component), ArgName = nameof(Component) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.Component) });
    }
}
