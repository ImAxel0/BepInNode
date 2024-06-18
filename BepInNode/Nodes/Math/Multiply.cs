using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class Multiply : Node
{
    public float First { get; set; }
    public float Second { get; set; }

    public Multiply()
    {
        Name = $"Multiply {FontAwesome6.Asterisk}";
        Description = "Multiplies two numeric values and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
