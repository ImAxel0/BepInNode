using BepInNode.NodeArguments;

namespace BepInNode.Nodes.GameObject;

public class GetTag : Node
{
    public GetTag()
    {
        Name = nameof(GetTag);
        Description = "Gets the tag of the passed GameObject";
        NodeCategory = NodeCategories.GameObject;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.GameObject), ArgName = nameof(GameObject) });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
