using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Transform;

public class TransformRight : Node
{
    public TransformRight()
    {
        Name = nameof(TransformRight);
        Description = "Manipulate a GameObject’s position on the X axis of the transform in world space";
        NodeCategory = NodeCategories.Transform;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
