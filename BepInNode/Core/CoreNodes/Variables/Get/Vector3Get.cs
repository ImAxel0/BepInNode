using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Core.CoreNodes.Variables.Get
{
    public class Vector3Get : Node
    {
        public Vector3Get()
        {
            Name = "Vector3Get";
            NodeType = NodeTypes.Variable;
            Description = "Gets the value of the Vector3 variable";
            NodeCategory = NodeCategories.Variables;

            ArgsOut.Add(new ArgOut { Type = typeof(Vector3) });
        }
    }
}
