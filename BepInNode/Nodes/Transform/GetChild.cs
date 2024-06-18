using BepInNode.NodeArguments;
using System.Xml.Serialization;

namespace BepInNode.Nodes.Transform;

public class GetChild : Node
{
    [XmlIgnore]
    public UnityEngine.Transform Transform { get; set; }

    public int Index { get; set; }

    public GetChild()
    {
        Name = nameof(GetChild);
        Description = "Returns a transform child by index.";
        NodeCategory = NodeCategories.Transform;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(Transform) });
        ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(Index) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.Transform) });
    }
}
