using BepInNode.NodeArguments;

namespace BepInNode.Nodes.Transform;

public class GetChildCount : Node
{
    public GetChildCount()
    {
        Name = nameof(GetChildCount);
        Description = "Returns the number of children in the passed transform";
        NodeCategory = NodeCategories.Transform;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(int) });
    }
}
