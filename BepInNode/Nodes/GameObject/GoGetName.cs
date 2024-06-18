using BepInNode.NodeArguments;

namespace BepInNode.Nodes.GameObject;

public class GoGetName : Node
{
    public GoGetName()
    {
        Name = nameof(GoGetName);
        Description = "Returns the name of the GameObject";
        NodeCategory = NodeCategories.GameObject;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.GameObject), ArgName = nameof(GameObject) });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
