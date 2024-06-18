using BepInNode.NodeArguments;
using System.Xml.Serialization;

namespace BepInNode.Nodes.GameObject;

public class SetActive : Node
{
    [XmlIgnore]
    public UnityEngine.GameObject GameObject { get; set; }
    public bool Value { get; set; }

    public SetActive()
    {
        Name = nameof(SetActive);
        Description = "Turns the passed GameObject on or off";
        NodeCategory = NodeCategories.GameObject;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.GameObject), ArgName = nameof(GameObject) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
