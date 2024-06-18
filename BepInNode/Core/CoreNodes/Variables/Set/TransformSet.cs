using BepInNode.CustomAttributes;
using BepInNode.NodeArguments;
using System.Xml.Serialization;

namespace BepInNode.Core.CoreNodes.Variables.Set;

public class TransformSet : Node
{
    [XmlIgnore]
    [IgnoreProperty]
    public UnityEngine.Transform ValueIn { get; set; }

    public TransformSet()
    {
        Name = "TransformSet";
        NodeType = NodeTypes.Variable;
        Description = "Sets the value of the Transform variable";
        NodeCategory = NodeCategories.Variables;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Transform), ArgName = nameof(UnityEngine.Transform) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.Transform) });
    }
}
