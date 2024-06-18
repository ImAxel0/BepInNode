using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Vec3;

public class Vector3Angle : Node
{
    public Vector3 From { get; set; }
    public Vector3 To { get; set; }

    public Vector3Angle()
    {
        Name = "Vector3.Angle";
        Description = "Calculates the angle between two vectors.";
        NodeCategory = NodeCategories.Vector3;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(From) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(To) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
