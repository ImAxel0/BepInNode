using BepInNode.NodeArguments;
using System.Xml.Serialization;
using UnityEngine;

namespace BepInNode.Nodes.Fields;

public class SetObjectFieldValue : Node
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string FieldName { get; set; }
    public object Value { get; set; }

    public SetObjectFieldValue()
    {
        Name = nameof(SetObjectFieldValue);
        Description = "Sets the field value of an object field contained in the passed component";
        NodeCategory = NodeCategories.Fields;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(FieldName) });
        ArgsIn.Add(new ArgIn { Type = typeof(object), ArgName = nameof(Value) });
    }
}
