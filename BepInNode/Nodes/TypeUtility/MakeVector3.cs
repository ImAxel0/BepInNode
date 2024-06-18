
using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.TypeUtility;

public class MakeVector3 : Node
{
    public float X {  get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public MakeVector3()
    {
        Name = nameof(MakeVector3);
        Description = "Makes a vector3 from three float input";
        NodeCategory = NodeCategories.TypeUtility;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(X) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Y) });
        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Z) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
