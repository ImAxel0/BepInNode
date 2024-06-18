using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Core.CoreNodes.Variables.Set
{
    public class Vector3Set : Node
    {
        public Vector3 ValueIn { get; set; }

        public Vector3Set()
        {
            Name = "Vector3Set";
            NodeType = NodeTypes.Variable;
            Description = "Sets the value of the Vector3 variable";
            NodeCategory = NodeCategories.Variables;

            ArgsIn.Add(new ArgIn { Type = typeof(Vector3), ArgName = nameof(ValueIn) });
            ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
        }
    }
}
