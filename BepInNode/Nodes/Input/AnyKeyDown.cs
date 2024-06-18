namespace BepInNode.Nodes.Input;

public class AnyKeyDown : Node
{
    public AnyKeyDown()
    {
        Name = nameof(AnyKeyDown);
        Description = "Returns true the first frame the user hits any key or mouse button.";
        NodeCategory = NodeCategories.Input;

        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(bool) });
    }
}
