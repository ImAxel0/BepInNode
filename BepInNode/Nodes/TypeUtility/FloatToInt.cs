using BepInNode.NodeArguments;

namespace BepInNode.Nodes.TypeUtility;

public class FloatToInt : Node
{
    public FloatToInt()
    {
        Name = nameof(FloatToInt);
        Description = "Convert float input to integer output";
        NodeCategory = NodeCategories.TypeUtility;
        SizeOverride = new(250, 110);

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = "float" });
        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}
