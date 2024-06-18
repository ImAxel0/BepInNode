using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.TypeUtility;

public class BreakVector2 : Node
{
    public BreakVector2()
    {
        Name = nameof(BreakVector2);
        Description = "Breaks a vector2 input to (x, y) float values";
        NodeCategory = NodeCategories.TypeUtility;
        SizeOverride = new(250, 150);

        ArgsIn.Add(new ArgIn { Type = typeof(Vector2), ArgName = "xy" });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
