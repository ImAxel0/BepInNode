using System.Xml.Serialization;

namespace BepInNode.Nodes.GameObject;

public class CompareTag : Node
{
    [XmlIgnore]
    public UnityEngine.GameObject GameObject { get; set; }
    public string Tag { get; set; }

    public CompareTag()
    {
        Name = nameof(CompareTag);
        Description = "Is this GameObject tagged with tag?";
        NodeCategory = NodeCategories.GameObject;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(UnityEngine.GameObject), ArgName = nameof(GameObject) });
        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(string), ArgName = nameof(Tag) });
        ArgsOut.Add(new NodeArguments.ArgOut { Type = typeof(bool) });
    }
}
