using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class LessThanEqual : Node
{
    public float First { get; set; }
    public float Second { get; set; }

    public LessThanEqual()
    {
        Name = $"LessThanEqual {FontAwesome6.LessThanEqual}";
        Description = "Returns true if first is less or equal to second";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
