using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class Subtract : Node
{
    public float First { get; set; }
    public float Second { get; set; }

    public Subtract()
    {
        Name = $"Subtract {FontAwesome6.SquareMinus}";
        Description = "Subtracts second from first and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
