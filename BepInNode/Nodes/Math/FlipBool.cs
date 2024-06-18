using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class FlipBool : Node
{
    public FlipBool()
    {
        Name = $"FlipBool {FontAwesome6.Exclamation}";
        Description = "Flips the passed boolean value";
        NodeCategory = NodeCategories.Math;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(bool) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
