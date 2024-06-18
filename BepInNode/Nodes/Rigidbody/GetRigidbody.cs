using BepInNode.NodeArguments;

namespace BepInNode.Nodes.Rigidbody;

public class GetRigidbody : Node
{
    public GetRigidbody()
    {
        Name = nameof(GetRigidbody);
        Description = "Gets the rigidbody component of the passed transform if it has one, else null";
        NodeCategory = NodeCategories.Rigidbody;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.Rigidbody) });
    }
}
