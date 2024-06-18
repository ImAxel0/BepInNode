using System.Numerics;

namespace BepInNode.Nodes.Input;

public class GetMouseScrollDelta : Node
{
    public GetMouseScrollDelta()
    {
        Name = nameof(GetMouseScrollDelta);
        Description = "The current mouse scroll delta.";
        NodeCategory = NodeCategories.Input;

        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(Vector2) });
    }
}
