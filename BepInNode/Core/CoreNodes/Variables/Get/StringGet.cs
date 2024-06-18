using BepInNode.NodeArguments;

namespace BepInNode.Core.CoreNodes.Variables.Get
{
    public class StringGet : Node
    {
        public StringGet()
        {
            Name = "StringGet";
            NodeType = NodeTypes.Variable;
            Description = "Gets the value of the string variable";
            NodeCategory = NodeCategories.Variables;

            ArgsOut.Add(new ArgOut { Type = typeof(string) });
        }
    }
}
