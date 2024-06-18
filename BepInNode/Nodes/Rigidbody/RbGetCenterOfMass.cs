using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Rigidbody;

public class RbGetCenterOfMass : Node
{
    public RbGetCenterOfMass()
    {
        Name = nameof(RbGetCenterOfMass);
        Description = "Returns the center of mass relative to the transform's origin.";
        NodeCategory = NodeCategories.Rigidbody;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
