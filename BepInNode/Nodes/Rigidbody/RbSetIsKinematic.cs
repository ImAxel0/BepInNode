using BepInNode.NodeArguments;
using System.Xml.Serialization;

namespace BepInNode.Nodes.Rigidbody;

public class RbSetIsKinematic : Node
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public bool Value { get; set; }

    public RbSetIsKinematic()
    {
        Name = nameof(RbSetIsKinematic);
        Description = "Controls whether physics affects the rigidbody.";
        NodeCategory = NodeCategories.Rigidbody;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(Value) });
    }
}
