using System.Xml.Serialization;

namespace BepInNode.Nodes.Rigidbody;

public class RbSetMass : Node
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public float Mass { get; set; }

    public RbSetMass()
    {
        Name = nameof(RbSetMass);
        Description = "Sets the mass of the rigidbody.";
        NodeCategory = NodeCategories.Rigidbody;

        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsIn.Add(new NodeArguments.ArgIn { Type = typeof(float), ArgName = nameof(Mass) });
    }
}
