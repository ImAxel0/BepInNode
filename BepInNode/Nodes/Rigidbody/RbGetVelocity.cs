using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Rigidbody;

public class RbGetVelocity : Node
{
    public RbGetVelocity()
    {
        Name = nameof(RbGetVelocity);
        Description = "The velocity vector of the rigidbody. It represents the rate of change of Rigidbody position.";
        NodeCategory = NodeCategories.Rigidbody;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
