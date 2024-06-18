using System.Numerics;

namespace BepInNode.Nodes.Vec3;

public class Vector3Normalize : Node
{
    public Vector3 Vector3 { get; set; }

    public Vector3Normalize()
    {
        Name = "Vector3.Normalize";
        Description = "Makes this vector have a magnitude of 1.";
        NodeCategory = NodeCategories.Vector3;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(Vector3), ArgName = nameof(Vector3) });
    }
}
