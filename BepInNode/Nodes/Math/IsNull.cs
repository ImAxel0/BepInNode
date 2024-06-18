using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class IsNull : Node
{
    public IsNull()
    {
        Name = $"IsNull {FontAwesome6.Question}";
        Description = "Returns true if passed object is null, else return false";
        NodeCategory = NodeCategories.Math;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(object) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
