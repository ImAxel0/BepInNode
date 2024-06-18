using System.Numerics;

namespace BepInNode.Nodes.Input;

public class GetMousePosition : Node
{
    public GetMousePosition()
    {
        Name = nameof(GetMousePosition);
        Description = "The current mouse position in pixel coordinates. (Z is always 0)";
        NodeCategory = NodeCategories.Input;

        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(Vector3) });
    }
}
