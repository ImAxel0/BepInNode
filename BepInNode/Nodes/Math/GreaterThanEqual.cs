using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class GreaterThanEqual : Node
{
    public float First { get; set; }
    public float Second { get; set; }

    public GreaterThanEqual()
    {
        Name = $"GreaterThanEqual {FontAwesome6.GreaterThanEqual}";
        Description = "Returns true if first is greater or equal to second";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
