using BepInNode.NodeArguments;

namespace BepInNode.Nodes.Vec3;

public class Vector3Magnitude : Node
{
    public System.Numerics.Vector3 Vector3 { get; set; }

    public Vector3Magnitude()
    {
        Name = "Vector3.Magnitude";
        Description = "Returns the length of this vector. The length of the vector is square root of (x*x+y*y+z*z)";
        NodeCategory = NodeCategories.Vector3;

        ArgsIn.Add(new ArgIn { Type = typeof(System.Numerics.Vector3), ArgName = nameof(Vector3) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
