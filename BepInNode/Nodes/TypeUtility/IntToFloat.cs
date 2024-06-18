using BepInNode.NodeArguments;

namespace BepInNode.Nodes.TypeUtility;

public class IntToFloat : Node
{
    public IntToFloat()
    {
        Name = nameof(IntToFloat);
        Description = "Convert int input to float output";
        NodeCategory = NodeCategories.TypeUtility;
        SizeOverride = new(250, 110);

        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = "int" });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
