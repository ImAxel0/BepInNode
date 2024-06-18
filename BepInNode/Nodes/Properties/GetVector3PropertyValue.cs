using BepInNode.NodeArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BepInNode.Nodes.Properties;

public class GetVector3PropertyValue : Node
{
    [XmlIgnore]
    public UnityEngine.Component Component { get; set; }
    public string PropertyName { get; set; }

    public GetVector3PropertyValue()
    {
        Name = "GetVector3PropertyValue";
        Description = "Gets the property value of a Vector3 property contained in the passed component";
        NodeCategory = NodeCategories.Properties;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PropertyName) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
