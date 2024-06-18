using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.Transform;

public class TransformUp : Node
{
    public TransformUp()
    {
        Name = nameof(TransformUp);
        Description = "Manipulate a GameObject’s position on the Y axis of the transform in world space";
        NodeCategory = NodeCategories.Transform;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
