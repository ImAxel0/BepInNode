using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class MultiplyVec3 : Node
{
    public System.Numerics.Vector3 First { get; set; }
    public System.Numerics.Vector3 Second { get; set; }

    public MultiplyVec3()
    {
        Name = $"MultiplyVec3 {FontAwesome6.Asterisk} {FontAwesome6.Asterisk} {FontAwesome6.Asterisk}";
        Description = "Multiplies two vector 3 and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(System.Numerics.Vector3), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(System.Numerics.Vector3), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(System.Numerics.Vector3) });
    }
}
