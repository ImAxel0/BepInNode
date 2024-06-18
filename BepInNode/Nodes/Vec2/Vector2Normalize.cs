using System.Numerics;

namespace BepInNode.Nodes.Vec2;

public class Vector2Normalize : Node
{
    public Vector2 Vector3 { get; set; }

    public Vector2Normalize()
    {
        Name = "Vector2.Normalize";
        Description = "Makes this vector have a magnitude of 1.";
        NodeCategory = NodeCategories.Vector2;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(Vector2), ArgName = nameof(Vector3) });
    }
}
