using BepInNode.NodeArguments;
using System.Xml.Serialization;
using System.Numerics;

namespace BepInNode.Nodes.GameObject;

public class InstantiateGameObject : Node
{
    [XmlIgnore]
    public UnityEngine.GameObject GameObject { get; set; }
    public Vector3 Pos { get; set; }
    public Vector3 Rot { get; set; }

    public InstantiateGameObject()
    {
        Name = nameof(InstantiateGameObject);
        Description = "Instantiate the passed GameObject at the given position and rotation. Outputs the instantiated GameObject";
        NodeCategory = NodeCategories.GameObject;

        ArgsIn.Add(new ArgIn { Type = typeof(UnityEngine.GameObject), ArgName = nameof(GameObject) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Pos) });
        ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(Rot) });
        ArgsOut.Add(new ArgOut { Type = typeof(UnityEngine.GameObject) });
    }
}
