using BepInNode.NodeArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BepInNode.Nodes.Fields;

public class SetVector3FieldValue : Node
{
    [XmlIgnore]
    public UnityEngine.Component Component { get; set; }
    public string FieldName { get; set; }
    public Vector3 Value { get; set; }

    public SetVector3FieldValue()
    {
        Name = nameof(SetVector3FieldValue);
        Description = "Sets the field value of a Vector3 field contained in the passed component";
        NodeCategory = NodeCategories.Fields;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(FieldName) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Value) });
    }
}
