using BepInNode.CustomAttributes;
using BepInNode.NodeArguments;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Numerics;

namespace BepInNode.Nodes.Transform;

public class TransformRotate : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }

    public Vector3 Rotation { get; set; }

    [IgnoreProperty]
    public UnityEngine.Space EnumValue { get; set; }

    [XmlIgnore]
    [JsonIgnore]
    public List<Enum> SpaceEnums { get; set; } = new();

    public TransformRotate()
    {
        Name = nameof(TransformRotate);
        Description = "Applies a rotation of eulerAngles.z degrees around the z-axis, eulerAngles.x degrees around the x-axis, and eulerAngles.y degrees around the y-axis";
        NodeCategory = NodeCategories.Transform;

        foreach (var key in Enum.GetValues(typeof(UnityEngine.Space)))
            SpaceEnums.Add((UnityEngine.Space)key);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Rotation) });
        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Space), ArgName = nameof(UnityEngine.Space) });
    }
}
