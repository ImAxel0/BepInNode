using IconFonts;
using BepInNode.NodeArguments;

namespace BepInNode.Nodes.Math;

public class Add : Node
{
    public float First { get; set; }
    public float Second { get; set; }

    public Add() 
    {
        Name = $"Add {FontAwesome6.SquarePlus}";
        Description = "Sum two numeric values and output the result";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
