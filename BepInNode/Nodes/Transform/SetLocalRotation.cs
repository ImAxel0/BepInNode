using BepInNode.NodeArguments;
using System.Xml.Serialization;
using System.Numerics;

namespace BepInNode.Nodes.Transform;

public class SetLocalRotation : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }

    public Vector3 Rotation { get; set; }

    public SetLocalRotation()
    {
        Name = nameof(SetLocalRotation);
        Description = "Sets the local rotation of the passed transform";
        NodeCategory = NodeCategories.Transform;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Rotation) });
    }
}
