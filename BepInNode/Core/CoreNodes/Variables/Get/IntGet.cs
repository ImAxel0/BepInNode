using BepInNode.NodeArguments;

namespace BepInNode.Core.CoreNodes.Variables.Get
{
    public class IntGet : Node
    {
        public IntGet()
        {
            Name = "IntGet";
            NodeType = NodeTypes.Variable;
            Description = "Gets the value of the integer variable";
            NodeCategory = NodeCategories.Variables;

            ArgsOut.Add(new ArgOut { Type = typeof(int) });
        }
    }
}
