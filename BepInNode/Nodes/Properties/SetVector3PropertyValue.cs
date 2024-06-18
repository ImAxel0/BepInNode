using BepInNode.NodeArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BepInNode.Nodes.Properties;

public class SetVector3PropertyValue : Node
{
    [XmlIgnore]
    public UnityEngine.Component Component { get; set; }
    public string PropertyName { get; set; }
    public Vector3 Value { get; set; }

    public SetVector3PropertyValue()
    {
        Name = "SetVector3PropertyValue";
        Description = "Sets the property value of a Vector3 property contained in the passed component. The property must have a SET accessor";
        NodeCategory = NodeCategories.Properties;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PropertyName) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Value) });
    }
}
