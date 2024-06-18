using BepInNode.NodeArguments;

namespace BepInNode.Nodes.Math;

public class StringCompare : Node
{
    public string First { get; set; }
    public string Second { get; set; }

    public StringCompare()
    {
        Name = "StringCompare";
        Description = "Returns true if the two strings are the same (case sensitive)";
        NodeCategory = NodeCategories.Math;

        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(First) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(Second) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
