using BepInNode.CustomAttributes;
using BepInNode.NodeArguments;
using Newtonsoft.Json;
using System.Xml.Serialization;
using UnityEngine;

namespace BepInNode.Nodes.Input;

public class GetKeyDown : Node
{
    [IgnoreProperty]
    public KeyCode EnumValue { get; set; }

    [JsonIgnore]
    [XmlIgnore]
    public List<Enum> KeyEnums { get; set; } = new();

    public GetKeyDown()
    {
        Name = nameof(GetKeyDown);
        Description = "Returns true once if the key is pressed";
        NodeCategory = NodeCategories.Input;

        foreach (var key in Enum.GetValues(typeof(KeyCode)))
            KeyEnums.Add((KeyCode)key);

        ArgsIn.Add(new ArgIn { Type = typeof(KeyCode), ArgName = nameof(KeyCode) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
