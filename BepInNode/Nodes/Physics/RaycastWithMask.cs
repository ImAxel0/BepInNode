using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Physics;

public class RaycastWithMask : Node
{
    public Vector3 Origin { get; set; }
    public Vector3 Direction { get; set; }
    public float MaxDistance { get; set; } = float.PositiveInfinity;
    public string LayerName { get; set; }

    public RaycastWithMask()
    {
        Name = nameof(RaycastWithMask);
        Description = "Cast a ray from the given origin to the given direction and max distance.\n" +
            "Returns true if it encounters a collider of the given layermask and stores info about it in the RaycastHit output structure";
        NodeCategory = NodeCategories.Physics;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Origin) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Direction) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(MaxDistance) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(LayerName) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.RaycastHit) });
    }
}
