using BepInNode.NodeArguments;

namespace BepInNode.Core.CoreNodes.Variables.Set
{
    public class FloatSet : Node
    {
        public float ValueIn { get; set; }

        public FloatSet()
        {
            Name = "FloatSet";
            NodeType = NodeTypes.Variable;
            Description = "Sets the value of the float variable";
            NodeCategory = NodeCategories.Variables;

            ArgsIn.Add(new ArgIn { Type = typeof(float), ArgName = nameof(ValueIn) });
            ArgsOut.Add(new ArgOut { Type = typeof(float) });
        }
    }
}
