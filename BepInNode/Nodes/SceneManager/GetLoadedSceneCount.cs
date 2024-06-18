namespace BepInNode.Nodes.SceneManager;

public class GetLoadedSceneCount : Node
{
    public GetLoadedSceneCount()
    {
        Name = nameof(GetLoadedSceneCount);
        Description = "Returns the number of loaded Scenes.";
        NodeCategory = NodeCategories.SceneManager;

        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(int) });
    }
}
