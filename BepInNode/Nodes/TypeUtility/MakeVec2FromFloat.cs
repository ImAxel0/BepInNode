using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.TypeUtility;

public class MakeVec2FromFloat : Node
{
    public float Value { get; set; }

    public MakeVec2FromFloat()
    {
        Name = nameof(MakeVec2FromFloat);
        Description = "Makes a vector2 from a float input where (x,y) are equals to the float value";
        NodeCategory = NodeCategories.TypeUtility;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector2) });
    }
}
