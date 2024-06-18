using UnityEngine.SceneManagement;

namespace BepInNode.Nodes.SceneManager;

public class GetSceneName : Node
{
    public GetSceneName()
    {
        Name = nameof(GetSceneName);
        Description = "Returns the Scene name";
        NodeCategory = NodeCategories.SceneManager;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(Scene), ArgName = nameof(Scene) });
        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(string) });
    }
}
