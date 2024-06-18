using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Rigidbody;

public class RbGetAngularVelocity : Node
{
    public RbGetAngularVelocity()
    {
        Name = nameof(RbGetAngularVelocity);
        Description = "Returns the angular velocity vector of the rigidbody measured in radians per second.";
        NodeCategory = NodeCategories.Rigidbody;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
