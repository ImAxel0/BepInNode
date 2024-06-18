using BepInNode.NodeArguments;
using System.Xml.Serialization;

namespace BepInNode.Nodes.Transform;

public class TransformFind : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }
    public string PathName { get; set; }

    public TransformFind()
    {
        Name = nameof(TransformFind);
        Description = "Finds and gets a child Transform of the passed Transform by the given name or path to it";
        NodeCategory = NodeCategories.Transform;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(PathName) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.Transform) });
    }
}
