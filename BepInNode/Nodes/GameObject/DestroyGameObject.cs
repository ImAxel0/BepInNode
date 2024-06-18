using System.Xml.Serialization;

namespace BepInNode.Nodes.GameObject;

public class DestroyGameObject : Node
{
    [XmlIgnore]
    public UnityEngine.GameObject GameObject { get; set; }
    public float Delay { get; set; }

    public DestroyGameObject()
    {
        Name = nameof(DestroyGameObject);
        Description = "Removes a GameObject with optional delay time";
        NodeCategory = NodeCategories.GameObject;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(UnityEngine.GameObject), ArgName = nameof(GameObject) });
        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(float), ArgName = nameof(Delay)  });
    }
}
