using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Vec3;

public class Vector3Lerp : Node
{
    public Vector3 A { get; set; }
    public Vector3 B { get; set; }
    public float T { get; set; }

    public Vector3Lerp()
    {
        Name = "Vector3.Lerp";
        Description = "Linearly interpolates between two points.";
        NodeCategory = NodeCategories.Vector3;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(A) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(B) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(T) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
