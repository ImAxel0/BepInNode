using BepInNode.NodeArguments;
using System.Xml.Serialization;
using UnityEngine;

namespace BepInNode.Nodes.Fields;

public class SetFloatFieldValue : Node
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string FieldName { get; set; }
    public float Value { get; set; }

    public SetFloatFieldValue()
    {
        Name = nameof(SetFloatFieldValue);
        Description = "Sets the field value of a float field contained in the passed component";
        NodeCategory = NodeCategories.Fields;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(FieldName) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
    }
}
