using BepInNode.NodeArguments;
using System.Xml.Serialization;
using System.Numerics;

namespace BepInNode.Nodes.Transform;

public class LookAt : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }

    public Vector3 LookDirection { get; set; }

    public LookAt()
    {
        Name = nameof(LookAt);
        Description = "Makes the Transform looks in a direction";
        NodeCategory = NodeCategories.Transform;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(LookDirection) });
    }
}
