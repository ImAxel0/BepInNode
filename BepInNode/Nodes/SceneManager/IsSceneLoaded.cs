using UnityEngine.SceneManagement;

namespace BepInNode.Nodes.SceneManager;

public class IsSceneLoaded : Node
{
    public IsSceneLoaded()
    {
        Name = nameof(IsSceneLoaded);
        Description = "IsLoaded is set to true after loading has completed and objects have been enabled.";
        NodeCategory = NodeCategories.SceneManager;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(Scene), ArgName = nameof(Scene) });
        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(bool) });
    }
}
