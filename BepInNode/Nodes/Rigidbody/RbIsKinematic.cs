using BepInNode.NodeArguments;

namespace BepInNode.Nodes.Rigidbody;

public class RbIsKinematic : Node
{
    public RbIsKinematic()
    {
        Name = nameof(RbIsKinematic);
        Description = "Does physics affects the rigidbody?";
        NodeCategory = NodeCategories.Rigidbody;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
