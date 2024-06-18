using BepInNode.NodeArguments;
using System.Xml.Serialization;
using UnityEngine;

namespace BepInNode.Nodes.Properties;

public class SetIntPropertyValue : Node
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string PropertyName { get; set; }
    public int Value { get; set; }

    public SetIntPropertyValue()
    {
        Name = "SetIntPropertyValue";
        Description = "Sets the property value of an integer property contained in the passed component. The property must have a SET accessor";
        NodeCategory = NodeCategories.Properties;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PropertyName) });
        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Value) });
    }
}
