using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Transform;

public class GetLocalRotation : Node
{
    public GetLocalRotation()
    {
        Name = nameof(GetLocalRotation);
        Description = "Gets the local rotation of the passed Transform";
        NodeCategory = NodeCategories.Transform;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
