using BepInNode.NodeArguments;
using System.Xml.Serialization;

namespace BepInNode.Nodes.Rigidbody;

public class RbSetDrag : Node
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public float Drag { get; set; }

    public RbSetDrag()
    {
        Name = nameof(RbSetDrag);
        Description = "Sets the drag of the object.";
        NodeCategory = NodeCategories.Rigidbody;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Drag) });
    }
}
