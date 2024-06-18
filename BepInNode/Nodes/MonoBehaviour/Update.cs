using IconFonts;

namespace BepInNode.Nodes.MonoBehaviour;

public class Update : Node
{
    public Update()
    {
        Name = $"Update {FontAwesome6.Infinity}";
        Description = "This node is called every frame, basically always";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.MonoBehaviour;
    }
}
