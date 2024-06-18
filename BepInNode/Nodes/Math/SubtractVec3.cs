using BepInNode.NodeArguments;
using IconFonts;
using System.Numerics;

namespace BepInNode.Nodes.Math;

public class SubtractVec3 : Node
{
    public Vector3 First { get; set; }
    public Vector3 Second { get; set; }

    public SubtractVec3()
    {
        Name = $"SubtractVec3 {FontAwesome6.SquareMinus} {FontAwesome6.SquareMinus} {FontAwesome6.SquareMinus}";
        Description = "Subtracts second from first and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
