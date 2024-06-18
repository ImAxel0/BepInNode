using BepInNode.NodeArguments;
using System.Xml.Serialization;
using UnityEngine;
using BepInNode.CustomAttributes;

namespace BepInNode.Core.CoreNodes.Variables.Set;

public class RigidbodySet : Node
{
    [XmlIgnore]
    [IgnoreProperty]
    public UnityEngine.Rigidbody ValueIn { get; set; }

    public RigidbodySet()
    {
        Name = "RigidbodySet";
        NodeType = NodeTypes.Variable;
        Description = "Sets the value of the Rigidbody variable";
        NodeCategory = NodeCategories.Variables;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.Rigidbody), ArgName = nameof(Rigidbody) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.Rigidbody) });
    }
}
