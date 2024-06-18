using System.Numerics;
using System.Xml.Serialization;

namespace BepInNode.Nodes.Rigidbody;

public class RbMove : Node
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public Vector3 Pos { get; set; }
    public Vector3 Rot { get; set; }

    public RbMove()
    {
        Name = nameof(RbMove);
        Description = "Moves the Rigidbody to position and rotates the Rigidbody to rotation.";
        NodeCategory = NodeCategories.Rigidbody;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(Vector3), ArgName = nameof(Pos) });
        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(Vector3), ArgName = nameof(Rot) });
    }
}
