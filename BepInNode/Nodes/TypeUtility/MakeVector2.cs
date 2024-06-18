using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.TypeUtility;

public class MakeVector2 : Node
{
    public float X { get; set; }
    public float Y { get; set; }

    public MakeVector2()
    {
        Name = nameof(MakeVector2);
        Description = "Makes a vector2 from two float input";
        NodeCategory = NodeCategories.TypeUtility;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(X) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Y) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector2) });
    }
}
