using System.Xml.Serialization;

namespace BepInNode.Nodes.Rigidbody;

public class RbSetAngularDrag : Node
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public float Drag { get; set; }

    public RbSetAngularDrag()
    {
        Name = nameof(RbSetAngularDrag);
        Description = "Sets the angular drag of the object.";
        NodeCategory = NodeCategories.Rigidbody;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(float), ArgName = nameof(Drag) });
    }
}
