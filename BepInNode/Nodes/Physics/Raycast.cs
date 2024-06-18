using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Physics;

public class Raycast : Node
{
    public Vector3 Origin { get; set; }
    public Vector3 Direction { get; set; }
    public float MaxDistance { get; set; } = float.PositiveInfinity;

    public Raycast()
    {
        Name = nameof(Raycast);
        Description = "Cast a ray from the given origin to the given direction and max distance.\n" +
            "Returns true if it encounters a collider and stores info about it in the RaycastHit output structure";
        NodeCategory = NodeCategories.Physics;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Origin) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Direction) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(MaxDistance) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.RaycastHit) });
    }
}
