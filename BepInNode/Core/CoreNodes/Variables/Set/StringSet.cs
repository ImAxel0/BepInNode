using BepInNode.NodeArguments;

namespace BepInNode.Core.CoreNodes.Variables.Set
{
    public class StringSet : Node
    {
        public string ValueIn { get; set; }

        public StringSet()
        {
            Name = "StringSet";
            NodeType = NodeTypes.Variable;
            Description = "Sets the value of the string variable";
            NodeCategory = NodeCategories.Variables;

            ArgsIn.Add(new ArgIn { Type = typeof(string), ArgName = nameof(ValueIn) });
            ArgsOut.Add(new ArgOut { Type = typeof(string) });
        }
    }
}
