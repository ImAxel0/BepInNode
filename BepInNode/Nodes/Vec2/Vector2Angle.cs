using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Vec2;

public class Vector2Angle : Node
{
    public Vector2 From { get; set; }
    public Vector2 To { get; set; }

    public Vector2Angle()
    {
        Name = "Vector2.Angle";
        Description = "Gets the unsigned angle in degrees between from and to.";
        NodeCategory = NodeCategories.Vector2;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector2), ArgName = nameof(From) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector2), ArgName = nameof(To) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
