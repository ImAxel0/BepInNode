using BepInNode.NodeArguments;

namespace BepInNode.Nodes.TypeUtility;

public class IntToString : Node
{
    public IntToString()
    {
        Name = nameof(IntToString);
        Description = "Convert integer input to string output";
        NodeCategory = NodeCategories.TypeUtility;
        SizeOverride = new(250, 110);

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = "int" });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
