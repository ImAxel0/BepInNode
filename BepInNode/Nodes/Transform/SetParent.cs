using BepInNode.NodeArguments;
using System.Xml.Serialization;

namespace BepInNode.Nodes.Transform;

public class SetParent : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }

    [XmlIgnore]
    public UnityEngine.Transform NewParent { get; set; }

    public bool WorldPositionStays { get; set; }

    public SetParent()
    {
        Name = nameof(SetParent);
        Description = "Sets the parent Transform of the passed transform\n" +
            "WorldPositionStays: if true, the parent-relative position, scale and rotation are modified such that the " +
            "object keeps the same world space position, rotation and scale as before.";
        NodeCategory = NodeCategories.Transform;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(NewParent) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(WorldPositionStays) });
    }
}
