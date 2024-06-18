using BepInNode.NodeArguments;

namespace BepInNode.Core.CoreNodes.Variables.Set
{
    public class IntSet : Node
    {
        public int ValueIn { get; set; }

        public IntSet()
        {
            Name = "IntSet";
            NodeType = NodeTypes.Variable;
            Description = "Sets the value of the integer variable";
            NodeCategory = NodeCategories.Variables;

            ArgsIn.Add(new ArgIn { Type = typeof(int), ArgName = nameof(ValueIn) });
            ArgsOut.Add(new ArgOut { Type = typeof(int) });
        }
    }
}
