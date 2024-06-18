using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class DivideVec3 : Node
{
    public System.Numerics.Vector3 First { get; set; }
    public System.Numerics.Vector3 Second { get; set; }

    public DivideVec3()
    {
        Name = $"DivideVec3 {FontAwesome6.Divide} {FontAwesome6.Divide} {FontAwesome6.Divide}";
        Description = "Divides first vector 3 by secoond and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(System.Numerics.Vector3), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(System.Numerics.Vector3), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(System.Numerics.Vector3) });
    }
}
