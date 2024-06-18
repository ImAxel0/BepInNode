using BepInNode.NodeArguments;
using System.Xml.Serialization;
using UnityEngine;

namespace BepInNode.Nodes.Properties;

public class SetStringPropertyValue : Node
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string PropertyName { get; set; }
    public string Value { get; set; }

    public SetStringPropertyValue()
    {
        Name = "SetStringPropertyValue";
        Description = "Sets the property value of a string property contained in the passed component. The property must have a SET accessor";
        NodeCategory = NodeCategories.Properties;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PropertyName) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Value) });
    }
}
