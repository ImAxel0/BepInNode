using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Physics;

public class RaycastHitPoint : Node
{
    public RaycastHitPoint()
    {
        Name = nameof(RaycastHitPoint);
        Description = "Gets the position of the collider hit by a Physics.Raycast";
        NodeCategory = NodeCategories.Physics;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.RaycastHit), ArgName = nameof(UnityEngine.RaycastHit) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
