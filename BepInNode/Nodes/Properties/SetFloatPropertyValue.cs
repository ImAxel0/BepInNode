using BepInNode.NodeArguments;
using System.Xml.Serialization;
using UnityEngine;

namespace BepInNode.Nodes.Properties;

public class SetFloatPropertyValue : Node
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string PropertyName { get; set; }
    public float Value { get; set; }

    public SetFloatPropertyValue()
    {
        Name = "SetFloatPropertyValue";
        Description = "Sets the property value of a float property contained in the passed component. The property must have a SET accessor";
        NodeCategory = NodeCategories.Properties;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PropertyName) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
    }
}
