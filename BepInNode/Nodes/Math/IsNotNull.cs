using BepInNode.NodeArguments;
using IconFonts;

namespace BepInNode.Nodes.Math;

public class IsNotNull : Node
{
    public IsNotNull()
    {
        Name = $"IsNotNullNode {FontAwesome6.Exclamation}{FontAwesome6.Question}";
        Description = "Returns true if passed object is not null, else return false";
        NodeCategory = NodeCategories.Math;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(object) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
