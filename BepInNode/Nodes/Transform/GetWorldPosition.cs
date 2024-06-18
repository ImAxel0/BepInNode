using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Transform;

public class GetWorldPosition : Node
{
    public GetWorldPosition()
    {
        Name = nameof(GetWorldPosition);
        Description = "Gets the world position of the passed Transform";
        NodeCategory = NodeCategories.Transform;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
