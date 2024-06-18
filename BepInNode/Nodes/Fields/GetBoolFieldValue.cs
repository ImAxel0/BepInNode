using BepInNode.NodeArguments;
using System.Xml.Serialization;
using UnityEngine;

namespace BepInNode.Nodes.Fields;

public class GetBoolFieldValue : Node
{
    [XmlIgnore]
    public Component Component { get; set; }
    public string FieldName { get; set; }

    public GetBoolFieldValue()
    {
        Name = nameof(GetBoolFieldValue);
        Description = "Gets the field value of a boolean field contained in the passed component";
        NodeCategory = NodeCategories.Fields;

        ArgsIn.Add(new ArgIn { Type = typeof(Component), ArgName = nameof(Component) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(FieldName) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
