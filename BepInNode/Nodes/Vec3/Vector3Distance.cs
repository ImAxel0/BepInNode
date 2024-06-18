using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Vec3;

public class Vector3Distance : Node
{
    public Vector3 A { get; set; }
    public Vector3 B { get; set; }

    public Vector3Distance()
    {
        Name = "Vector3.Distance";
        Description = "Returns the distance between the two vectors A and B";
        NodeCategory = NodeCategories.Vector3;

        ArgsIn.Add(new ArgIn { Type = typeof(System.Numerics.Vector3), ArgName = nameof(A) });
        ArgsIn.Add(new ArgIn { Type = typeof(System.Numerics.Vector3), ArgName = nameof(B) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
