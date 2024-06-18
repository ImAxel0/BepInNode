using BepInNode.NodeArguments;

namespace BepInNode.Nodes.Physics;

public class RaycastHitRigidbody : Node
{
    public RaycastHitRigidbody()
    {
        Name = nameof(RaycastHitRigidbody);
        Description = "Gets the Rigidbody of the collider hit by a Physics.Raycast";
        NodeCategory = NodeCategories.Physics;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.RaycastHit), ArgName = nameof(UnityEngine.RaycastHit) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.Rigidbody) });
    }
}
