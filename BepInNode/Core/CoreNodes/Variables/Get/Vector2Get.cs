using BepInNode.NodeArguments;
using System.Numerics;

namespace BepInNode.Core.CoreNodes.Variables.Get
{
    public class Vector2Get : Node
    {
        public Vector2Get()
        {
            Name = "Vector2Get";
            NodeType = NodeTypes.Variable;
            Description = "Gets the value of the Vector2 variable";
            NodeCategory = NodeCategories.Variables;

            ArgsOut.Add(new ArgOut { Type = typeof(Vector2) });
        }
    }
}
