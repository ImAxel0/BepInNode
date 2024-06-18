using BepInNode.NodeArguments;
using System.Xml.Serialization;
using System.Numerics;

namespace BepInNode.Nodes.Rigidbody;

public class RbSetVelocity : Node
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public Vector3 Velocity { get; set; }

    public RbSetVelocity()
    {
        Name = nameof(RbSetVelocity);
        Description = "Sets the velocity vector of the rigidbody. It represents the rate of change of Rigidbody position.";
        NodeCategory = NodeCategories.Rigidbody;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Velocity) });
    }
}
