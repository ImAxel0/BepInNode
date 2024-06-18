namespace BepInNode.Nodes.GameObject;

public class FindGameObject : Node
{
    public string name { get; set; }

    public FindGameObject()
    {
        Name = nameof(FindGameObject);
        Description = "Finds an active GameObject by name";
        NodeCategory = NodeCategories.GameObject;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(string), ArgName = nameof(name) });
        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(UnityEngine.GameObject) });
    }
}
