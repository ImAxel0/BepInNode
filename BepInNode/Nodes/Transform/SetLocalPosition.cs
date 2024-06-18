using BepInNode.NodeArguments;
using System.Numerics;
using System.Xml.Serialization;

namespace BepInNode.Nodes.Transform;

public class SetLocalPosition : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }

    public Vector3 xyz { get; set; }

    public SetLocalPosition()
    {
        Name = nameof(SetLocalPosition);
        Description = "Sets the local position of the passed transform";
        NodeCategory = NodeCategories.Transform;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(xyz) });
    }
}
