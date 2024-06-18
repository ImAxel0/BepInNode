using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Nodes.TypeUtility;

public class Vec3ToString : Node
{
    public Vec3ToString()
    {
        Name = nameof(Vec3ToString);
        Description = "Convert vector3 input to string output";
        NodeCategory = NodeCategories.TypeUtility;
        SizeOverride = new(250, 110);

        ArgsIn.Add(new ArgIn { Type = typeof(Vector3) });
        ArgsOut.Add(new ArgOut { Type = typeof(string) });
    }
}
