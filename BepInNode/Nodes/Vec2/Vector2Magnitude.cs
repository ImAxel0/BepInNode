using BepInNode.NodeArguments;

namespace BepInNode.Nodes.Vec2;

public class Vector2Magnitude : Node
{
    public System.Numerics.Vector2 Vector3 { get; set; }

    public Vector2Magnitude()
    {
        Name = "Vector2.Magnitude";
        Description = "Returns the length of this vector.";
        NodeCategory = NodeCategories.Vector2;

        ArgsIn.Add(new ArgIn { Type = typeof(System.Numerics.Vector2), ArgName = nameof(Vector3) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
