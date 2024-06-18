using BepInNode.NodeArguments;
using System.Xml.Serialization;
using System.Numerics;

namespace BepInNode.Nodes.Transform;

public class SetEulerAngles : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }

    public Vector3 xyz { get; set; }

    public SetEulerAngles()
    {
        Name = nameof(SetEulerAngles);
        Description = "Sets the rotation as Euler angles in degrees.";
        NodeCategory = NodeCategories.Transform;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(xyz) });
    }
}
