using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class DivideVec3ByNumber : Node
{
    public System.Numerics.Vector3 First { get; set; }
    public float Second { get; set; }

    public DivideVec3ByNumber()
    {
        Name = $"DivideVec3ByNumber {FontAwesome6.Divide} {FontAwesome6.Divide} {FontAwesome6.Divide}";
        Description = "Divides first vector 3 by second float value and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(System.Numerics.Vector3), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(System.Numerics.Vector3) });
    }
}
