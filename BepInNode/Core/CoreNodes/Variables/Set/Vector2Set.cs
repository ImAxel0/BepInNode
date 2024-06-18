using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Core.CoreNodes.Variables.Set;

public class Vector2Set : Node
{
    public Vector2 ValueIn { get; set; }

    public Vector2Set()
    {
        Name = "Vector2Set";
        NodeType = NodeTypes.Variable;
        Description = "Sets the value of the Vector2 variable";
        NodeCategory = NodeCategories.Variables;

        ArgsIn.Add(new ArgIn { Type = typeof(Vector2), ArgName = nameof(ValueIn) });
        ArgsOut.Add(new ArgOut { Type = typeof(Vector2) });
    }
}
