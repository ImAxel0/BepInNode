using BepInNode.NodeArguments;

namespace BepInNode.Nodes.GameObject;

public class ActiveSelf : Node
{
    public ActiveSelf()
    {
        Name = nameof(ActiveSelf);
        Description = "Returns true if the passed GameObject is active, else returns false";
        NodeCategory = NodeCategories.GameObject;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.GameObject), ArgName = nameof(GameObject) });
        ArgsOut.Add(new ArgOut { Type = typeof(bool) });
    }
}
