using BepInNode.NodeArguments;

namespace BepInNode.Nodes.TypeUtility;

public class BoolToString : Node
{
    public BoolToString()
    {
        Name = nameof(BoolToString);
        Description = "Convert boolean input to string output";
        NodeCategory = NodeCategories.TypeUtility;
        SizeOverride = new(250, 110);

        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = "bool" });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
