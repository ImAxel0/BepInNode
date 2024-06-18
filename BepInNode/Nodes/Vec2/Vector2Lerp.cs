using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Vec2;

public class Vector2Lerp : Node
{
    public Vector2 A { get; set; }
    public Vector2 B { get; set; }
    public float T { get; set; }

    public Vector2Lerp()
    {
        Name = "Vector2.Lerp";
        Description = "Linearly interpolates between vectors a and b by t.";
        NodeCategory = NodeCategories.Vector2;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector2), ArgName = nameof(A) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector2), ArgName = nameof(B) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(T) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector2) });
    }
}
