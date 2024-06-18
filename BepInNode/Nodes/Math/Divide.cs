using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class Divide : Node
{
    public float First { get; set; }
    public float Second { get; set; }

    public Divide()
    {
        Name = $"Divide {FontAwesome6.Divide}";
        Description = "Divides first by second and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
