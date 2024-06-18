using BepInNode.NodeArguments;

namespace BepInNode.Nodes.Transform;

public class GetParent : Node
{
    public GetParent()
    {
        Name = nameof(GetParent);
        Description = "Gets the parent Transform of the passed transform";
        NodeCategory = NodeCategories.Transform;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.Transform) });
    }
}
