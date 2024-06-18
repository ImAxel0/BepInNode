namespace BepInNode.Nodes.SceneManager;

public class GetActiveScene : Node
{
    public GetActiveScene()
    {
        Name = nameof(GetActiveScene);
        Description = "Gets the currently active Scene.";
        NodeCategory = NodeCategories.SceneManager;

        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(UnityEngine.SceneManagement.Scene) });
    }
}
