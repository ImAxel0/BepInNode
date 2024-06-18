using BepInNode.NodeArguments;
using System.Xml.Serialization;

namespace BepInNode.Nodes.GameObject;

public class GoGetComponent : Node
{
    [XmlIgnore]
    public UnityEngine.GameObject GameObject { get; set; }
    public string ComponentName { get; set; }

    public GoGetComponent()
    {
        Name = nameof(GoGetComponent);
        Description = "Gets a component of the passed GameObject by name";
        NodeCategory = NodeCategories.GameObject;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.GameObject), ArgName = nameof(GameObject) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(ComponentName) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.Component) });
    }
}
