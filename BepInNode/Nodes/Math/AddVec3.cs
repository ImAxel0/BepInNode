using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class AddVec3 : Node
{
    public System.Numerics.Vector3 First { get; set; }
    public System.Numerics.Vector3 Second { get; set; }

    public AddVec3()
    {
        Name = $"AddVec3 {FontAwesome6.SquarePlus} {FontAwesome6.SquarePlus} {FontAwesome6.SquarePlus}";
        Description = "Sum two vector 3 and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(System.Numerics.Vector3), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(System.Numerics.Vector3), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(System.Numerics.Vector3) });
    }
}
