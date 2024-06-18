using UnityEngine.SceneManagement;

namespace BepInNode.Nodes.SceneManager;

public class GetSceneIndex : Node
{
    public GetSceneIndex()
    {
        Name = nameof(GetSceneIndex);
        Description = "Returns the index of the Scene in the Build Settings.";
        NodeCategory = NodeCategories.SceneManager;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(Scene), ArgName = nameof(Scene) });
        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(int) });
    }
}
