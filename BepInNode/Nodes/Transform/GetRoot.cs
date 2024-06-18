using BepInNode.NodeArguments;

namespace BepInNode.Nodes.Transform;

public class GetRoot : Node
{
    public GetRoot()
    {
        Name = nameof(GetRoot);
        Description = "Gets the root Transform of the passed Transform (the Transform at the top of the hierarchy)";
        NodeCategory = NodeCategories.Transform;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.Transform) });
    }
}
