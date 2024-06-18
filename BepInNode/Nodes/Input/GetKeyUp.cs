using BepInNode.CustomAttributes;
using BepInNode.NodeArguments;
using Newtonsoft.Json;
using System.Xml.Serialization;
using UnityEngine;

namespace BepInNode.Nodes.Input;

public class GetKeyUp : Node
{
    [IgnoreProperty]
    public KeyCode EnumValue { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> KeyEnums { get; set; } = new();

    public GetKeyUp()
    {
        Name = nameof(GetKeyUp);
        Description = "Returns true once when the key is released";
        NodeCategory = NodeCategories.Input;

        ArgsIn.Add(new ArgIn { Type = typeof(KeyCode), ArgName = nameof(KeyCode) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
