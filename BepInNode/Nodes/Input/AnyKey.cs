namespace BepInNode.Nodes.Input;

public class AnyKey : Node
{
    public AnyKey()
    {
        Name = nameof(AnyKey);
        Description = "Is any key or mouse button currently held down?";
        NodeCategory = NodeCategories.Input;

        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(bool) });
    }
}
