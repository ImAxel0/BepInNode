using IconFonts;

namespace BepInNode.Nodes.MonoBehaviour;

public class FixedUpdate : Node
{
    public FixedUpdate()
    {
        Name = $"FixedUpdate {FontAwesome6.PersonRunning}";
        Description = "This node is mainly used for physics based calculations, like moving objects around using rigidbodies";
        NodeType = NodeTypes.Starter;
        NodeCategory = NodeCategories.MonoBehaviour;
    }
}
