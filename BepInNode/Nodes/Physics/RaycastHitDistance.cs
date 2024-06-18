using BepInNode.NodeArguments;

namespace BepInNode.Nodes.Physics;

public class RaycastHitDistance : Node
{
    public RaycastHitDistance()
    {
        Name = nameof(RaycastHitDistance);
        Description = "Gets the distance of the collider hit by a Physics.Raycast from the ray origin";
        NodeCategory = NodeCategories.Physics;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.RaycastHit), ArgName = nameof(UnityEngine.RaycastHit) });
        ArgsOut.Add(new ArgOut { Type = typeof(float) });
    }
}
