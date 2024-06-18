namespace BepInNode.Nodes.SceneManager;

public class GetSceneByName : Node
{
    public string SceneName { get; set; }

    public GetSceneByName()
    {
        Name = nameof(GetSceneByName);
        Description = "Searches through the Scenes loaded for a Scene with the given name.";
        NodeCategory = NodeCategories.SceneManager;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(string), ArgName = nameof(SceneName) });
        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(UnityEngine.SceneManagement.Scene) });
    }
}
