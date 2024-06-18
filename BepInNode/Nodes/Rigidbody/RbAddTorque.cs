using BepInNode.CustomAttributes;
using BepInNode.NodeArguments;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Numerics;

namespace BepInNode.Nodes.Rigidbody;

public class RbAddTorque : Node
{
    [XmlIgnore]
    public UnityEngine.Rigidbody Rigidbody { get; set; }
    public Vector3 Direction { get; set; }

    [IgnoreProperty]
    public UnityEngine.ForceMode EnumValue { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> ForceModes { get; set; } = new();

    public RbAddTorque()
    {
        Name = nameof(RbAddTorque);
        Description = "Adds a torque force to the passed rigidbody in the given direction and type";
        NodeCategory = NodeCategories.Rigidbody;

        foreach (var forceMode in Enum.GetValues(typeof(UnityEngine.ForceMode)))
            ForceModes.Add((UnityEngine.ForceMode)forceMode);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Direction) });
        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.ForceMode), ArgName = nameof(UnityEngine.ForceMode) });
    }
}
