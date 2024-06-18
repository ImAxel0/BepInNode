using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class LessThan : Node
{
    public float First { get; set; }
    public float Second { get; set; }

    public LessThan()
    {
        Name = $"LessThan {FontAwesome6.LessThan}";
        Description = "Returns true if first is less than second";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
