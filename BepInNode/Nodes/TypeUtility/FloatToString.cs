using BepInNode.NodeArguments;

namespace BepInNode.Nodes.TypeUtility;

public class FloatToString : Node
{
    public FloatToString()
    {
        Name = nameof(FloatToString);
        Description = "Convert float input to string output";
        NodeCategory = NodeCategories.TypeUtility;
        SizeOverride = new(250, 110);

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = "float" });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
