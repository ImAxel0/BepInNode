using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.TypeUtility;

public class BreakVector3 : Node
{
    public BreakVector3()
    {
        Name = nameof(BreakVector3);
        Description = "Breaks a vector3 input to (x, y, z) float values";
        NodeCategory = NodeCategories.TypeUtility;
        SizeOverride = new(250, 150);

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = "xyz" });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
