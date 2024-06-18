namespace BepInNode.Nodes.SceneManager;

public class GetSceneAt : Node
{
    public int Index { get; set; }

    public GetSceneAt()
    {
        Name = nameof(GetSceneAt);
        Description = "Get the Scene at index in the SceneManager's list of loaded Scenes.";
        NodeCategory = NodeCategories.SceneManager;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(int), ArgName = nameof(Index) });
        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(UnityEngine.SceneManagement.Scene) });
    }
}
