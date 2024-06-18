using System.Numerics;
using System.Xml.Serialization;

namespace BepInNode.Nodes.Transform;

public class TransformDirection : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }

    public Vector3 Direction { get; set; }

    public TransformDirection()
    {
        Name = nameof(TransformDirection);
        Description = "Transforms direction from local space to world space.";
        NodeCategory = NodeCategories.Transform;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(Vector3), ArgName = nameof(Direction) });
        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(Vector3) });
    }
}
