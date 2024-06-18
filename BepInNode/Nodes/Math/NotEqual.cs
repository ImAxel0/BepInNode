using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class NotEqual : Node
{
    public float First { get; set; }
    public float Second { get; set; }

    public NotEqual()
    {
        Name = $"NotEqual {FontAwesome6.NotEqual}";
        Description = "Returns true if the two numeric values aren't the same";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
