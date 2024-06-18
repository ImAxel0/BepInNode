using BepInNode.NodeArguments;

namespace BepInNode.Nodes.Transform;

public class DetachParent : Node
{
    public DetachParent()
    {
        Name = nameof(DetachParent);
        Description = "Detaches the parent Transform from the passed transform";
        NodeCategory = NodeCategories.Transform;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
    }
}
