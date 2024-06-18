using BepInNode.NodeArguments;
using System.Xml.Serialization;
using UnityEngine;

namespace BepInNode.Nodes.Fields;

public class SetIntFieldValue : Node
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string FieldName { get; set; }
    public int Value { get; set; }

    public SetIntFieldValue()
    {
        Name = nameof(SetIntFieldValue);
        Description = "Sets the field value of an integer field contained in the passed component";
        NodeCategory = NodeCategories.Fields;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(FieldName) });
        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Value) });
    }
}
