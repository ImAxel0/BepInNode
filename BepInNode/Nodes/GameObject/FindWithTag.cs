namespace BepInNode.Nodes.GameObject;

public class FindWithTag : Node
{
    public string Tag { get; set; }

    public FindWithTag()
    {
        Name = nameof(FindWithTag);
        Description = "Returns one active GameObject tagged tag. Returns null if no GameObject was found.";
        NodeCategory = NodeCategories.GameObject;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(string), ArgName = nameof(Tag) });
        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(UnityEngine.GameObject) });
    }
}
