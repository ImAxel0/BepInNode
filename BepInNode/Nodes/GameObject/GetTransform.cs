using BepInNode.NodeArguments;

namespace BepInNode.Nodes.GameObject;

public class GetTransform : Node
{
    public GetTransform()
    {
        Name = nameof(GetTransform);
        Description = "Gets the Transform of the passed GameObject";
        NodeCategory = NodeCategories.GameObject;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.GameObject), ArgName = nameof(GameObject) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.Transform) });
    }
}
