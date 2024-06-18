using BepInNode.NodeArguments;
using System.Numerics;
using System.Xml.Serialization;

namespace BepInNode.Nodes.Transform;

public class SetLocalScale : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }
    public Vector3 Scale { get; set; }

    public SetLocalScale()
    {
        Name = nameof(SetLocalScale);
        Description = "Changes the local scale of the passed transform";
        NodeCategory = NodeCategories.Transform;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Scale) });
    }
}
