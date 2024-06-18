namespace BepInNode.Nodes.SceneManager;

public class UnloadSceneAsync : Node
{
    public string SceneName { get; set; }

    public UnloadSceneAsync()
    {
        Name = nameof(UnloadSceneAsync);
        Description = "Destroys all GameObjects associated with the given Scene and removes the Scene from the SceneManager.";
        NodeCategory = NodeCategories.SceneManager;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(string), ArgName = nameof(SceneName) });
    }
}
