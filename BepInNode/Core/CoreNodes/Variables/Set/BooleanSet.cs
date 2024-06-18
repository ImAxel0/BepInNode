using BepInNode.NodeArguments;

namespace BepInNode.Core.CoreNodes.Variables.Set
{
    public class BooleanSet : Node
    {
        public bool ValueIn { get; set; }

        public BooleanSet()
        {
            Name = "BoolSet";
            NodeType = NodeTypes.Variable;
            Description = "Sets the value of the boolean variable";
            NodeCategory = NodeCategories.Variables;

            ArgsIn.Add(new ArgIn { Type = typeof(bool), ArgName = nameof(ValueIn) });
            ArgsOut.Add(new ArgOut { Type = typeof(bool) });
        }
    }
}
