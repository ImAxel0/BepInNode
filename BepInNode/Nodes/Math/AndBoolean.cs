using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class AndBoolean : Node
{
    public AndBoolean()
    {
        Name = $"AND Boolean {FontAwesome6.CheckDouble}";
        Description = "Returns true if both of the inputs are true";
        NodeCategory = NodeCategories.Math;
        SizeOverride = new(250, 140);

        ArgsIn.Add(new ArgIn { Type = typeof(bool) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
