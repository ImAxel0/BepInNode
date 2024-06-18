using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class MultiplyVec3ByNumber : Node
{
    public System.Numerics.Vector3 First { get; set; }
    public float Second { get; set; }

    public MultiplyVec3ByNumber()
    {
        Name = $"MultiplyVec3ByNumber {FontAwesome6.Asterisk} {FontAwesome6.Asterisk} {FontAwesome6.Asterisk}";
        Description = "Multiplies a vector 3 with a float and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(System.Numerics.Vector3), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(System.Numerics.Vector3) });
    }
}
