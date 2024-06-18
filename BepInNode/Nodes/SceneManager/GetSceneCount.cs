namespace BepInNode.Nodes.SceneManager;

public class GetSceneCount : Node
{
    public GetSceneCount()
    {
        Name = nameof(GetSceneCount);
        Description = "Returns the current number of Scenes.";
        NodeCategory = NodeCategories.SceneManager;

        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(int) });
    }
}
