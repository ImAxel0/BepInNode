using BepInNode.NodeArguments;

namespace BepInNode.Core.CoreNodes.Variables.Get
{
    public class BooleanGet : Node
    {
        public BooleanGet()
        {
            Name = "BoolGet";
            NodeType = NodeTypes.Variable;
            Description = "Gets the value of the boolean variable";
            NodeCategory = NodeCategories.Variables;

            ArgsOut.Add(new ArgOut { Type = typeof(bool) });
        }
    }
}
