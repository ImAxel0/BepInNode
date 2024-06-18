
using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.TypeUtility;

public class MakeVec3FromFloat : Node
{
    public float Value { get; set; }

    public MakeVec3FromFloat()
    {
        Name = nameof(MakeVec3FromFloat);
        Description = "Makes a vector3 from a float input where (x,y,z) are equals to the float value";
        NodeCategory = NodeCategories.TypeUtility;

        ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(Value) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
    }
}
