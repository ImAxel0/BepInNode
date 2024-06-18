using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class OrBoolean : Node
{
    public OrBoolean()
    {
        Name = $"OR Boolean {FontAwesome6.GripLinesVertical}";
        Description = "Returns true if atleast one of the inputs is true";
        NodeCategory = NodeCategories.Math;
        SizeOverride = new(250, 140);

        ArgsIn.Add(new ArgIn { Type = typeof(bool) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
