using BepInNode.NodeArguments;
using UnityEngine;
using System.Xml.Serialization;
using BepInNode.CustomAttributes;

namespace BepInNode.Core.CoreNodes.Variables.Set;

public class GameObjectSet : Node
{
    [XmlIgnore]
    [IgnoreProperty]
    public UnityEngine.GameObject ValueIn { get; set; }

    public GameObjectSet()
    {
        Name = "GameObjectSet";
        NodeType = NodeTypes.Variable;
        Description = "Sets the value of the GameObject variable";
        NodeCategory = NodeCategories.Variables;
        SizeOverride = new(250, 120);

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.GameObject), ArgName = nameof(GameObject) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.GameObject) });
    }
}
