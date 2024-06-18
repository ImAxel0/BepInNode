using BepInNode.CustomAttributes;
using BepInNode.NodeArguments;

namespace BepInNode.Core.CoreNodes.Variables.Set
{
    public class ObjectSet : Node
    {
        [IgnoreProperty]
        public object ValueIn { get; set; }

        public ObjectSet()
        {
            Name = "ObjectSet";
            NodeType = NodeTypes.Variable;
            Description = "Sets the value of the object variable";
            NodeCategory = NodeCategories.Variables;
            SizeOverride = new(250, 120);

            ArgsIn.Add(new ArgIn { Type = typeof(object), ArgName = nameof(ValueIn) });
            ArgsOut.Add(new ArgOut { Type = typeof(object) });
        }
    }
}
