using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Transform;

public class GetEulerAngles : Node
{
    public GetEulerAngles()
    {
        Name = nameof(GetEulerAngles);
        Description = "The rotation as Euler angles in degrees.";
        NodeCategory = NodeCategories.Transform;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
