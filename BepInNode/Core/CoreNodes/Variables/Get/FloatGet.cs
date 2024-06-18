using BepInNode.NodeArguments;

namespace BepInNode.Core.CoreNodes.Variables.Get
{
    public class FloatGet : Node
    {
        public FloatGet()
        {
            Name = "FloatGet";
            NodeType = NodeTypes.Variable;
            Description = "Gets the value of the float variable";
            NodeCategory = NodeCategories.Variables;

            ArgsOut.Add(new ArgOut { Type = typeof(float) });
        }
    }
}
