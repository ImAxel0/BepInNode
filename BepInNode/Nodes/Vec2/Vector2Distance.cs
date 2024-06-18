using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Vec2;

public class Vector2Distance : Node
{
    public Vector2 A { get; set; }
    public Vector2 B { get; set; }

    public Vector2Distance()
    {
        Name = "Vector2.Distance";
        Description = "Returns the distance between a and b.";
        NodeCategory = NodeCategories.Vector2;

        ArgsIn.Add(new ArgIn { Type = typeof(System.Numerics.Vector2), ArgName = nameof(A) });
        ArgsIn.Add(new ArgIn { Type = typeof(System.Numerics.Vector2), ArgName = nameof(B) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
