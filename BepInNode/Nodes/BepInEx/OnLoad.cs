using IconFonts;

namespace BepInNode.Nodes.BepInEx;

public class OnLoad : Node
{
    public OnLoad()
    {
        Name = $"OnLoad {FontAwesome6.ScrewdriverWrench}";
        Description = "Called upon mod initialization";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.BepInEx;
    }
}
